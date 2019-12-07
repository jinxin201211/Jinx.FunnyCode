USE [MovieWarehouse]


SELECT *
FROM [MovieWarehouse].[dbo].[Douban_Movie_Popular]
ORDER BY [Time] DESC, [Order]


SELECT DISTINCT ID,Title FROM [MovieWarehouse].[dbo].[Douban_Movie_Popular]



SELECT COUNT(*)
FROM [MovieWarehouse].[dbo].[Douban_Celebrity_ID]
WHERE [Read]=0


SELECT COUNT(*)
FROM [MovieWarehouse].[dbo].[Douban_Celebrity_ID]
WHERE [Read]=1


SELECT *
FROM [MovieWarehouse].[dbo].[Douban_Celebrity_ID]
WHERE [FZF]=1


SELECT *
FROM [MovieWarehouse].[dbo].[Douban_Movie_ID]


UPDATE [MovieWarehouse].[dbo].[Douban_Celebrity_ID] SET [Read]=0


SELECT COUNT(*)
FROM [MovieWarehouse].[dbo].Douban_Movie_ID
WHERE [Read]=0


SELECT * FROM Douban_Movie_Info WHERE Directors LIKE '/' or Casts LIKE '/' or Writers LIKE '/'  
SELECT COUNT(*) FROM Douban_Movie_Info
