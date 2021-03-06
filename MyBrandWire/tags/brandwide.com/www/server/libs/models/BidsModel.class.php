<?php

class BidsModel
{
    public static function getNotPublishedBidsList()
    {
        $sql = "
            SELECT n.id, n.header, n.common, n.status, n.publish_time, o.payment, o.idCompany, m.login AS moderator,
                o.idModerator = ? AS is_bind_to_you
            FROM news AS n
            JOIN orders AS o
                ON o.id = n.idOrder
                AND o.isPublish = 1
            LEFT JOIN moderators AS m
                ON o.idModerator = m.idModerator
            WHERE n.isBlog = 0
                 AND n.is_delete = 0
            ORDER BY id DESC
        ";
        return Database::query($sql, array(Config::$moderatorId));
    }   
    
    public static function getBidInfo($id)
    {
        $sql = "
            SELECT n.id, n.header, n.common, n.content, n.tags, n.status, n.comments,
                o.payment, o.idCompany, o.grammerCheck, m.login AS moderator,
                m.idModerator = ? AS is_bind_to_you, c.idUser, n.publish_time
            FROM news AS n
            JOIN orders AS o
                ON o.id = n.idOrder
            LEFT JOIN moderators AS m
                ON o.idModerator = m.idModerator
            JOIN company AS c
                ON c.id = o.idCompany
            WHERE n.id = ?
            LIMIT 1
        ";
        return Database::query($sql, array(Config::$moderatorId, $id));
    }
    
    public static function updateBidInfo($id, $header, $common, $content, $tags, $publishTime)
    {
        $sql = "
            UPDATE news
            SET header = ?,
                common = ?,
                content = ?,
                tags = ?,
                publish_time = ?
            WHERE id = ?
            LIMIT 1
        ";
        Database::query($sql, array($header, $common, $content, $tags, $publishTime, $id));
        return Database::getRows();
    }
    
    public static function setOrthographyIsChecked($id) 
    {
        $sql = "
            UPDATE news 
                SET status = 'spell_checked'
            WHERE id = ?
            LIMIT 1
        ";
        Database::query($sql, array($id));
        return Database::getRows();
    }
    
    public static function setApprovalPassed($id)
    {
        $sql = "
            UPDATE news 
                SET status = 'moderated'
            WHERE id = ?
            LIMIT 1
        ";
        Database::query($sql, array($id));

        $sql1 = "
            UPDATE orders
                SET isPublish = '1'
            WHERE id IN (SELECT idOrder FROM news WHERE news.id = ? )
            LIMIT 1
        ";
        Database::query($sql1, array($id));
        return 1;
    }
    
    public static function bindModeratorToBid($bidId, $moderatorId)
    {
        $sql = "
            UPDATE `orders` AS o, `news` AS n
            SET o.`idModerator` = ?
            WHERE n.`id` = ?
                AND o.`id` = n.`idOrder`
        ";
        Database::query($sql, array($moderatorId, $bidId));      
        return Database::getRows();
    }
    
    public static function getClientLastNews($clientId, $count)
    {
        $sql = "
            SELECT n.id, n.header, n.status
            FROM news AS n
            JOIN orders AS o 
                ON o.id = n.idOrder
            JOIN company AS c 
                ON c.idUser = ?
                AND c.id = o.idCompany
            WHERE n.is_delete = 0
            ORDER BY n.id DESC
            LIMIT ?
        ";
        return Database::query($sql, array($clientId, $count));
    }
    
    public static function deleteNew($newId) 
    {
        $sql = "
            UPDATE news
            SET is_delete = 1
            WHERE id = ?
            LIMIT 1
        ";
        $result = Database::query($sql, array($newId));
        return 1;
    }

    public static function setStatusPayed($newId)
    {
        $sql = "
            UPDATE news
            SET status = 'payed'
            WHERE id = ?
            LIMIT 1
        ";
        $result = Database::query($sql, array($newId));
//        $sql1 = "
//            UPDATE orders
//                SET isPublish = '0'
//            WHERE id IN (SELECT idOrder FROM news WHERE news.id = ? )
//            LIMIT 1
//        ";
//        Database::query($sql1, array($newId));
        return 1;
    }

    public static function setStatusEdit($newId)
    {
        $sql = "
            UPDATE news
            SET status = 'editPublishedNews'
            WHERE id = ?
            LIMIT 1
        ";
        $result = Database::query($sql, array($newId));
//        $sql1 = "
//            UPDATE orders
//                SET isPublish = '0'
//            WHERE id IN (SELECT idOrder FROM news WHERE news.id = ? )
//            LIMIT 1
//        ";
//        Database::query($sql1, array($newId));
        return 1;
    }
};

?>
