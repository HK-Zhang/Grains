CREATE VIEW View_BlogPostCounts AS 
        SELECT Name, Count(p.PostMId) as PostCount from BlogMs b
        JOIN PostMs p on p.BlogMId = b.BlogMId
        GROUP BY b.Name