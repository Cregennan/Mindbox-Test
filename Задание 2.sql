SELECT p.name as ProductName, c.name as CategoryName
FROM Product p
    LEFT JOIN ProductCategory pc on p.id = pc.product_id
    LEFT JOIN Category c on pc.category_id = c.id
