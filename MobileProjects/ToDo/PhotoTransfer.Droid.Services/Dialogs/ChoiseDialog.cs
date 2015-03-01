using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ToDo.Droid.Services.Dialogs.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.Droid.Services.Dialogs
{
	public class ChoiseDialog<T> where T : IHeaderedItem
	{
		#region ClickListener
		
		private class OnCancelListener : IDialogInterfaceOnCancelListener
		{
			Action<IDialogInterface> modOnCancel;

			public OnCancelListener(Action<IDialogInterface> onCancel)
			{
				this.modOnCancel = onCancel;
			}

			public void OnCancel(IDialogInterface dialog)
			{
				if (modOnCancel != null)
				{
					modOnCancel(dialog);
				}
			}

			public IntPtr Handle
			{
				get 
				{
					return default(IntPtr);
				}
			}

			public void Dispose()
			{
				
			}
		}

		#endregion

		#region Fields

		IListAdapter modItemsAdapter;
		IEnumerable<T> modRealItems;

		#endregion

		#region Constructor

		public ChoiseDialog(IEnumerable<T> items)
		{
			InitAdapter(items);
		}

		#endregion

		#region Private methods

		void InitAdapter(IEnumerable<T> items)
		{
			modRealItems = items;
			modItemsAdapter = new ArrayAdapter<string>(Forms.Context, Resource.Layout.TextViewItem, items.Select(x => x.Header).ToArray());
		}

		#endregion

		#region Public methods

		public async Task<T> ShowAndSelectOneAsync(string title)
		{			
			var taskCompletionSource = new TaskCompletionSource<T>();

			try
			{
				var dialogBuilder = new AlertDialog.Builder(Forms.Context)
					.SetTitle(title)
					.SetCancelable(true)
					.SetSingleChoiceItems(modItemsAdapter, -1,
						(o, e) =>
						{
							(o as IDialogInterface).Dismiss();
							taskCompletionSource.SetResult(modRealItems.ElementAt(e.Which));
						})
					.SetOnCancelListener(new OnCancelListener(o => taskCompletionSource.SetResult(default(T))))
					.Show();
			}
			catch (Exception ex)
			{
				taskCompletionSource.SetResult(default(T));
			}

			return await taskCompletionSource.Task;
		}

		#endregion
	}
}