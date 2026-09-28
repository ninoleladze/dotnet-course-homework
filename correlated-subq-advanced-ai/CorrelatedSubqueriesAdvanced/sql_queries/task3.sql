-- Task 3: Leading manufacturer (by total quantity sold) for each product title.
-- If the product title was never sold, the leading manufacturer is NULL.
-- Ties are broken by the lowest manufacturer id.

SELECT
    pt.id AS product_id,
    pt.title AS title,
    m.id AS manufacturer_id,
    m.name AS manufacturer
FROM product_title pt
LEFT JOIN manufacturer m ON m.id = (
    SELECT p.manufacturer_id
    FROM product p
    JOIN order_details od ON od.product_id = p.id
    WHERE p.product_title_id = pt.id
    GROUP BY p.manufacturer_id
    ORDER BY SUM(od.product_amount) DESC, p.manufacturer_id ASC
    LIMIT 1
)
ORDER BY pt.id ASC;
