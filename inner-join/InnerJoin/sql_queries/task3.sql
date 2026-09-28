SELECT DISTINCT product_title.title AS title,
                product.price AS price
FROM product
INNER JOIN product_title ON product.product_title_id = product_title.id
INNER JOIN order_details ON order_details.product_id = product.id
INNER JOIN customer_order ON customer_order.id = order_details.customer_order_id
INNER JOIN customer ON customer.person_id = customer_order.customer_id
INNER JOIN person ON person.id = customer.person_id
WHERE person.birth_date BETWEEN '2000-01-01' AND '2010-12-31'
ORDER BY product_title.title ASC, product.price ASC;
