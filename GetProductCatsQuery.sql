SELECT "Products"."Name", cats.catName 
FROM "Products"
LEFT JOIN 
	(SELECT "ProductCats"."Product" AS product, "Category"."CatName" AS catName
	FROM "ProductCats"
	INNER JOIN "Category"
	ON "ProductCats"."Category" = "Category"."Id")  AS cats
ON cats.product = "Products"."Id"