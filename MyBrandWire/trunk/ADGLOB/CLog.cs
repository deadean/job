﻿using System;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
namespace ADGLOB
{
	/// <summary>
	/// Type of log record
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// Points to record that represents regular information
		/// </summary>
		INF,
		/// <summary>
		/// Points to record that represents error
		/// </summary>
		ERR,
		/// <summary>
		/// Points to record that represents debug information
		/// </summary>
		DBG
	}

	/// <summary>
	/// Mode of log notifications.
	/// </summary>
	public enum LogMode
	{
		/// <summary>
		/// Short error message.
		/// </summary>
		Short = 0,
		/// <summary>
		/// Full error message which contains number and text of the oracle error and etc.
		/// </summary>
		Full = 1,
		/// <summary>
		/// Short error message with button "Details" - full error.
		/// </summary>
		ShortWithDetails = 2,
		/// <summary>
		/// Short error message with button "Details" and button "Send email" - notification about error".
		/// </summary>
		ShortWithDetailsAndManualEmail = 3,
		/// <summary>
		/// Short error message with automaticaly send email about error.
		/// </summary>
		ShortAndAutomaticalyEmail = 4,
		/// <summary>
		/// Full error message with automaticaly send email about error.
		/// </summary>
		FullAndAutomaticalyEmail = 5,
		/// <summary>
		/// Short error message with bytton "Details" - full error and automaticaly send email about error.
		/// </summary>
		ShortWithDetailsAndAutomaticalyEmail = 6
	}

	/// <summary>
	/// Class which represents one log record.
	/// </summary>
	public class LogRecord
	{
		/// <summary>
		/// Current process identificator
		/// </summary>
		private int modProcessId = Process.GetCurrentProcess().Id;
		/// <summary>
		/// Current thread identificator
		/// </summary>
		private int modThreadId = Thread.CurrentThread.ManagedThreadId;
		/// <summary>
		/// Current session identificator, -1 means that connection is not opened yet.
		/// </summary>
		private int modDbSessionId = -1;
		/// <summary>
		/// Type of log record
		/// </summary>
		private LogType mvLogType = LogType.INF;
		/// <summary>
		/// Message of log record
		/// </summary>
		private string mvMessage = string.Empty;
		/// <summary>
		/// Exception that should be logged in log record
		/// </summary>
		private Exception mvException = null;
		/// <summary>
		/// Type of object that wish to add a log record
		/// </summary>
		private Type mvObjectThatWishToLog = null;
		/// <summary>\
		/// Delimiter that separates fields in log record
		/// </summary>
		private static string mvFieldDelimiter = "\u2588";
		/// <summary>
		/// Format of log record
		/// </summary>
		private static string mvLogFormat = "{LOGTYPE}  {DELIM}  {DATETIME}  {DELIM}  {PROCESSID}  {DELIM}  {THREADID}  {DELIM}  {DBSESSIONID}  {DELIM}  {OBJNAME}  {DELIM}  {MESSAGE}  {DELIM}  {EXCMESSAGE}  {DELIM}  {STACK}";

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logException">The log exception.</param>
		public LogRecord(Exception logException)
			: this(logException, (DbConnection)null)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(Exception logException, DbConnection connection)
			: this(string.Empty, (Type)null, logException, connection)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logException">The log exception.</param>
		public LogRecord(string logMessage, Exception logException)
			: this(logMessage, logException, (DbConnection)null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(string logMessage, Exception logException, DbConnection connection)
			: this(logMessage, (Type)null, logException, connection)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		public LogRecord(Type logObject, Exception logException)
			: this(logObject, logException, (DbConnection)null)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(Type logObject, Exception logException, DbConnection connection)
			: this(string.Empty, logObject, logException, connection)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">Object that makes logging.</param>
		/// <param name="logException">The log exception.</param>
		public LogRecord(string logMessage, Type logObject, Exception logException)
			: this(logMessage, logObject, logException, (DbConnection)null)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">Object that makes logging.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(string logMessage, Type logObject, Exception logException, DbConnection connection)
			: this(LogType.ERR, logMessage, logObject, logException, connection)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		public LogRecord(string logMessage)
			: this(logMessage, (DbConnection)null)
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(string logMessage, DbConnection connection)
			: this(LogType.INF, logMessage, connection)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		public LogRecord(LogType logType, string logMessage)
			: this(logType, logMessage, (DbConnection)null)
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(LogType logType, string logMessage, DbConnection connection)
			: this(logType, logMessage, (Type)null, connection)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		public LogRecord(LogType logType, string logMessage, Type logObject)
			: this(logType, logMessage, logObject, (DbConnection)null)
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">Object that makes logging.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(LogType logType, string logMessage, Type logObject, DbConnection connection)
			: this(logType, logMessage, logObject, (Exception)null, connection)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">Object that makes logging.</param>
		/// <param name="logException">The log exception.</param>
		public LogRecord(LogType logType, string logMessage, Type logObject, Exception logException)
			: this(logType, logMessage, logObject, logException, (DbConnection)null)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="LogRecord"/> class.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">Object that makes logging.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">Connection which SID should be used in log record</param>
		public LogRecord(LogType logType, string logMessage, Type logObject, Exception logException, DbConnection connection)
		{
			try
			{
				LogType = logType;
				Message = logMessage;
				ObjectThatWishToLog = logObject;
				Exception = logException;

				//if (CLog.IsStarted)
				//{
				//  if (connection != null)
				//    modDbSessionId = CDataBase.Sid(connection);
				//  else
				//    modDbSessionId = CDataBase.Sid();
				//}


				//StackTrace st = new StackTrace(true);
				//for (int i = 0; i < st.FrameCount; i++)
				//{
				//  // Note that high up the call stack, there is only
				//  // one stack frame.
				//  StackFrame sf = st.GetFrame(i);
				//  System.Diagnostics.Debug.Print("Method: {0}", sf.GetMethod());
				//}
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
				//CLog.Log("LogRecord(LogType logType, string logMessage, Type logObject, Exception logException, DbConnection connection)", exc);
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			string result = String.Empty;

			try
			{
				result = mvLogFormat.Replace("{LOGTYPE}", mvLogType.ToString()).
					Replace("{DELIM}", mvFieldDelimiter).
					Replace("{DATETIME}", DateTime.Now.ToUniversalTime().ToString("o")).
					Replace("{PROCESSID}", modProcessId.ToString()).
					Replace("{THREADID}", modThreadId.ToString()).
					Replace("{DBSESSIONID}", modDbSessionId.ToString()).
					Replace("{MESSAGE}", mvMessage);

				if (mvObjectThatWishToLog != null)
					result = result.Replace("{OBJNAME}", mvObjectThatWishToLog.FullName);
				else
					result = result.Replace("{OBJNAME}", string.Empty);


				string excStackTrace = String.Empty;
				string excMessage = String.Empty;

				if (mvException != null)
				{
					if (mvException.InnerException != null)
					{
						excStackTrace = mvException.InnerException.StackTrace;
						excMessage = mvException.InnerException.Message;
					}
					excStackTrace = excStackTrace + Environment.NewLine + mvException.StackTrace;
					excStackTrace = excStackTrace + Environment.NewLine + "FULL STACK TRACE:" + Environment.NewLine + Environment.StackTrace;
					excMessage = excMessage + " - " + mvException.Message;
				}

				result = result.Replace("{STACK}", excStackTrace);
				result = result.Replace("{EXCMESSAGE}", excMessage);


				//if (mvException != null)
				//{
				//    result = result.Replace("{STACK}", mvException.StackTrace);
				//    result = result.Replace("{EXCMESSAGE}", mvException.Message);
				//}
				//else
				//{
				//    result = result.Replace("{STACK}", string.Empty);
				//    result = result.Replace("{EXCMESSAGE}", string.Empty);
				//}
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}

			return result.Replace("\n", "\n\t");
		}

		///// <summary>
		///// Sets the connection.
		///// </summary>
		///// <value>The connection.</value>
		//public DbConnection Connection
		//{
		//    set { modDbSessionId = CDataBase.Sid(value); }
		//}

		/// <summary>
		/// Gets or sets the type of the log.
		/// </summary>
		/// <value>The type of the log.</value>
		public LogType LogType
		{
			get { return mvLogType; }
			set { mvLogType = value; }
		}

		/// <summary>
		/// Gets or sets the log format.
		/// </summary>
		/// <value>The log format.</value>
		public static string LogFormat
		{
			get { return mvLogFormat; }
			set { mvLogFormat = value; }
		}

		/// <summary>
		/// Gets or sets the field delimiter.
		/// </summary>
		/// <value>The field delimiter.</value>
		public static string FieldDelimiter
		{
			get { return mvFieldDelimiter; }
			set { mvFieldDelimiter = value; }
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message
		{
			get { return mvMessage; }
			set { mvMessage = value; }
		}

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>The exception.</value>
		public Exception Exception
		{
			get { return mvException; }
			set { mvException = value; }
		}

		/// <summary>
		/// Gets or sets the object that wish to log.
		/// </summary>
		/// <value>The object that wish to log.</value>
		public Type ObjectThatWishToLog
		{
			get { return mvObjectThatWishToLog; }
			set { mvObjectThatWishToLog = value; }
		}
	}

	/// <summary>
	/// Static class which adds log records to log file
	/// </summary>
	public static class CLog
	{
		private static int modTempMessageListMaxCountCLog = 10;

		private static object mvLocker = new object();



		//static string mutexName = "ADAICA.Core.CLog Write";
		//private static volatile Mutex mutex = null;

		public static int TempMessageListMaxCount
		{
			get
			{
				return modTempMessageListMaxCountCLog;
			}
			set
			{
				if (value > 0 && value < 50)
					modTempMessageListMaxCountCLog = value;
			}

		}
		private static List<string> modTempMessageListCLog = new List<string>();

		//private static LogMode modLogMode = LogMode.Short;

		public static LogMode Mode { get; set; }

		/// <summary>
		/// Path to log file
		/// </summary>
		private static string modLogPath = string.Empty;

		/// <summary>
		///  log file name
		/// </summary>
		private static string modLogFileName = string.Empty;

		/// <summary>
		/// Lock that makes possible to use one log from various threads simultaneously
		/// </summary>
		private static object logFileLock = new object();
		/// <summary>
		/// Whether starting log message already added to log file.
		/// </summary>
		private static bool isStarted = false;
		/// <summary>
		/// Gets a value indicating whether logging is started.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if logging is started; otherwise, <c>false</c>.
		/// </value>
		public static bool IsStarted
		{
			get { return isStarted; }
		}

		public static LogType LogLevel
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the name of the log full file.
		/// </summary>
		/// <value>The name of the log full file.</value>
		public static string LogFullFileName
		{
			get { return modLogPath; }
			set { modLogPath = value; }
		}
		public static string LogFileName
		{
			get
			{
				return modLogFileName;
			}
			set
			{

				string name = System.AppDomain.CurrentDomain.FriendlyName;
				if (!name.Contains("ADAICA.exe"))
					modLogFileName = value;
			}

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CLog"/> class.
		/// </summary>
		static CLog()
		{

			try
			{
				string name = System.AppDomain.CurrentDomain.FriendlyName;
				modTempMessageListMaxCountCLog = 1;
#if DEBUG
				LogLevel = LogType.DBG;



#else
				LogLevel = LogType.ERR;
#endif
				//string directoryName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\";
				//if ( !Directory.Exists( directoryName ) )
				//    Directory.CreateDirectory( directoryName );

				//bool mutexWasCreated = false;
				//bool requestInitialOwnership = true;

				string timenow = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
				modLogFileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + timenow + ".log";
                modLogPath = String.Empty;

				//if (name.Contains("ADAICA.exe") || name.Contains("ADAICA.vshost.exe"))
				if (name.ToLower().Contains("adaica.exe") || name.ToLower().Contains("adaica.vshost.exe"))
				{
					//mutex = new Mutex(requestInitialOwnership, modLogFileName, out mutexWasCreated);
					//mutex = Mutex.OpenExisting(modLogFileName);
					isStarted = true;
				}
			}
			catch (Exception /*exc*/)
			{
				//MessageBox.Show("Can't start logging: " + e.Message + "  " + e.StackTrace, "Logging is not started", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		/// <summary>
		/// Logs the specified log exception.
		/// The type of log record is ERR in this case.
		/// </summary>
		/// <param name="logException">The log exception.</param>
		public static void Log(Exception logException)
		{
			try
			{
				Log(logException, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log exception for apropriate connection.
		/// The type of log record is ERR in this case.
		/// </summary>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(Exception logException, DbConnection connection)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(string.Empty, logObject, logException, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log message for exception.
		/// The type of log record is ERR in this case.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logException">The log exception.</param>
		public static void Log(string logMessage, Exception logException)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(logMessage, logObject, logException, (DbConnection)null);

				//Log( logMessage, logException, ( DbConnection ) null );
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log message for log exception and connection.
		/// The type of log record is ERR in this case.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(string logMessage, Exception logException, DbConnection connection)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(logMessage, logObject, logException, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log exception.
		/// The type of log record is ERR in this case.
		/// </summary>
		/// <param name="logObject">The type of object that logs the record.</param>
		/// <param name="logException">The log exception.</param>
		public static void Log(Type logObject, Exception logException)
		{
			try
			{
				Log(logObject, logException, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log exception that called logObject type with apropriate connection.
		/// </summary>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(Type logObject, Exception logException, DbConnection connection)
		{
			try
			{
				Log(string.Empty, logObject, logException, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log message that called logObject type with logException exception.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object type.</param>
		/// <param name="logException">The log exception.</param>
		public static void Log(string logMessage, Type logObject, Exception logException)
		{
			try
			{
				Log(logMessage, logObject, logException, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log message.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(string logMessage, Type logObject, Exception logException, DbConnection connection)
		{
			try
			{
				Log(LogType.ERR, logMessage, logObject, logException, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log message.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		public static void Log(string logMessage)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(LogType.INF, logMessage, logObject, (DbConnection)null);
				//Log( logMessage, ( DbConnection ) null );
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

        public static void Log(string nameFunction, string logMessage)
        {
            try
            {
                Log(String.Format("Function : {0}, Message : {1}", nameFunction, logMessage));
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.Print(exc.ToString());
            }
        }
		/// <summary>
		/// Logs the specified log message.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(string logMessage, DbConnection connection)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(LogType.INF, logMessage, logObject, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log message.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		public static void Log(string logMessage, Type logObject)
		{
			try
			{
				Log(logMessage, logObject, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log message.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(string logMessage, Type logObject, DbConnection connection)
		{
			try
			{
				Log(LogType.INF, logMessage, logObject, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		public static void Log(LogType logType, string logMessage)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}

				Log(logType, logMessage, logObject, (DbConnection)null);

				//Log( logType, logMessage, ( DbConnection ) null );
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(LogType logType, string logMessage, DbConnection connection)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				Log(logType, logMessage, logObject, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		public static void Log(LogType logType, string logMessage, Type logObject)
		{
			try
			{
				Log(logType, logMessage, logObject, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(LogType logType, string logMessage, Type logObject, DbConnection connection)
		{
			try
			{
				Log(logType, logMessage, logObject, (Exception)null, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		public static void LogError(string logMessage)
		{
			try
			{
				LogError(logMessage, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="connection">The connection.</param>
		public static void LogError(string logMessage, DbConnection connection)
		{
			try
			{
				Type logObject = null;
				try
				{
					logObject = (new StackTrace(1, true)).GetFrame(0).GetMethod().DeclaringType;
				}
				catch
				{
				}
				LogError(logMessage, logObject, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		public static void LogError(string logMessage, Type logObject)
		{
			try
			{
				Log(logMessage, logObject, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="connection">The connection.</param>
		public static void LogError(string logMessage, Type logObject, DbConnection connection)
		{
			try
			{
				Log(LogType.ERR, logMessage, logObject, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		public static void Log(LogType logType, string logMessage, Type logObject, Exception logException)
		{
			try
			{
				Log(logType, logMessage, logObject, logException, (DbConnection)null);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}
		/// <summary>
		/// Logs the specified log type.
		/// </summary>
		/// <param name="logType">Type of the log.</param>
		/// <param name="logMessage">The log message.</param>
		/// <param name="logObject">The log object.</param>
		/// <param name="logException">The log exception.</param>
		/// <param name="connection">The connection.</param>
		public static void Log(LogType logType, string logMessage, Type logObject, Exception logException, DbConnection connection)
		{
			try
			{
				if (logType <= LogLevel)
                    LogToFile(logMessage+LogRecord.FieldDelimiter+logException);

				//CLogEntLib.Log(logType, logMessage, logObject, logException, connection);
				//	CLogEntLib.Log(logType, logMessage, logObject, logException, connection);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		/// <summary>
		/// Logs the specified log record.
		/// </summary>
		/// <param name="logRecord">The log record.</param>
		public static void Log(LogRecord logRecord)
		{
			try
			{
				LogToFile(logRecord.ToString());
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		//private static volatile Mutex mutex = null;

		/// <summary>
		/// Logs to file.
		/// </summary>
		/// <param name="message">The message.</param>
		static void LogToFile(string message)
		{
			try
			{
				lock (mvLocker)
				{
                    using (FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("ERROR :"+message);
                            sw.Close();
                        }
                        fs.Close();
                    }
				}
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.Print(exc.ToString());
			}
		}

		static void LogInThreadFromTempMessageList(object messageIn)
		{
			try
			{

				//catch (AbandonedMutexException exc) { if (exc.Mutex != null) exc.Mutex.ReleaseMutex(); }
				using (FileStream fs = new FileStream(modLogPath, FileMode.Append, FileAccess.Write, FileShare.Write))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						foreach (string st in (List<string>)messageIn)
						{
							sw.WriteLine(st);
						}
						sw.Close();
					}
					fs.Close();
				}
			}
			catch (Exception e)//AbandonedMutexException exc
			{
#if DEBUG
				modTempMessageListCLog.InsertRange(0, (List<string>)messageIn);
#endif
				//if (exc.Mutex != null) exc.Mutex.ReleaseMutex();
				//mutex.ReleaseMutex();
				//ThreadPool.QueueUserWorkItem(new WaitCallback(LogInThreadFromTempMessageList), messageIn);
			}
			//finally{mutex.ReleaseMutex();}
		}
		//		static void LogToFileOld(string message)
		//		{
		//			try
		//			{
		//				if (modLogPath.Length > 0)
		//				{
		//					Thread threaderPrint = new Thread(LogInThread);
		//					threaderPrint.IsBackground = true;
		//					threaderPrint.Start(message);
		//				}
		//			}
		//			catch (Exception exc)
		//			{
		//				System.Diagnostics.Debug.Print(exc.ToString());
		//			}
		//		}

		//		static void LogInThread(object message)
		//		{
		//			try
		//			{
		//while (File.Exists(modLogPath + ".lock")) ;
		//
		//				lock (logFileLock)
		//				{
		//int i;
		//for ( i = 0; i < 10; i++ )
		//{
		//					bool isCreateNew = false;
		//					Mutex m = new Mutex(true, "adaica.log", out isCreateNew);
		//
		//					try
		//					{
		//FileStream fs = File.Create(modLogPath + ".lock");
		//						File.AppendAllText(modLogPath, (string)message + Environment.NewLine);
		//fs.Close();
		//File.Delete(modLogPath + ".lock");
		//break;
		//					}
		//					catch (Exception exc)
		//					{
		//						System.Diagnostics.Debug.Print("LOG2 " + exc.ToString());
		//#if DEBUG
		//						MessageBox.Show("Error simultaneous access to the file: " + exc.Message, "Logging.", MessageBoxButton.OK, MessageBoxImage.Error);
		//#endif
		//					}
		//
		//					m.Close();
		//				}
		//}
		//			}
		//			catch (Exception exc)
		//			{
		//				System.Diagnostics.Debug.Print(exc.ToString());
		//#if DEBUG
		//				MessageBox.Show("Error mutex" + exc.Message, "Logging.", MessageBoxButton.OK, MessageBoxImage.Error);
		//#endif
		//			}
		//		}
	}
}
