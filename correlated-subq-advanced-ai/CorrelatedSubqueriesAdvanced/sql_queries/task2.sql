-- Task 2: For every product, compare quantity sold with a discount above 5%
-- against quantity sold with a discount of 5% or less (or none), and the
-- percentage difference between the two.

SELECT
    id,
    title,
    count_with_discount_5,
    count_without_discount_5,
    ROUND(
        CASE
            WHEN (count_with_discount_5 + count_without_discount_5) = 0 THEN 0.0
            ELSE (count_with_discount_5 - count_without_discount_5) * 100.0
                 / (count_with_discount_5 + count_without_discount_5)
        END, 2
    ) AS difference
FROM (
    SELECT
        p.id AS id,
        p.comment AS title,
        COALESCE((
            SELECT SUM(od.product_amount)
            FROM order_details od
            JOIN customer_order co ON co.id = od.customer_order_id
            LEFT JOIN customer c ON c.person_id = co.customer_id
            WHERE od.product_id = p.id
              AND COALESCE(c.discount, 0) > 0.05
        ), 0) AS count_with_discount_5,
        COALESCE((
            SELECT SUM(od.product_amount)
            FROM order_details od
            JOIN customer_order co ON co.id = od.customer_order_id
            LEFT JOIN customer c ON c.person_id = co.customer_id
            WHERE od.product_id = p.id
              AND COALESCE(c.discount, 0) <= 0.05
        ), 0) AS count_without_discount_5
    FROM product p
) t
ORDER BY id ASC;
