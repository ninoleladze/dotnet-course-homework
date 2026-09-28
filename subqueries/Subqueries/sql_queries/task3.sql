SELECT co.id AS order_id, COUNT(od.id) AS items_count
FROM customer_order co
JOIN order_details od ON od.customer_order_id = co.id
WHERE strftime('%Y', co.operation_time) = '2021'
GROUP BY co.id
HAVING COUNT(od.id) > (
    SELECT AVG(cnt)
    FROM (
        SELECT COUNT(od3.id) AS cnt
        FROM customer_order co3
        JOIN order_details od3 ON od3.customer_order_id = co3.id
        GROUP BY co3.id
    ) sub2
)
ORDER BY items_count ASC, order_id ASC
