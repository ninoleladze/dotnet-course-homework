-- Task 1: Customers whose average purchase amount per order-line is more than 70.
-- Sorted ascending by total purchase sum, then surname.
-- Anonymous orders (customer_id IS NULL) are grouped together as one row with NULL name/surname.

SELECT
    name,
    surname,
    ROUND(avg_purchase, 2) AS avg_purchase,
    ROUND(sum_purchase, 2) AS sum_purchase
FROM (
    SELECT
        p.name AS name,
        p.surname AS surname,
        (
            SELECT AVG(od.price_with_discount * od.product_amount)
            FROM order_details od
            JOIN customer_order co ON co.id = od.customer_order_id
            WHERE co.customer_id = c.customer_id
               OR (co.customer_id IS NULL AND c.customer_id IS NULL)
        ) AS avg_purchase,
        (
            SELECT SUM(od.price_with_discount * od.product_amount)
            FROM order_details od
            JOIN customer_order co ON co.id = od.customer_order_id
            WHERE co.customer_id = c.customer_id
               OR (co.customer_id IS NULL AND c.customer_id IS NULL)
        ) AS sum_purchase
    FROM (SELECT DISTINCT customer_id FROM customer_order) c
    LEFT JOIN person p ON p.id = c.customer_id
) t
WHERE avg_purchase > 70
ORDER BY sum_purchase ASC, surname ASC;
