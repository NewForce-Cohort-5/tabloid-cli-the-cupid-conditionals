

--UPDATE Author 
                                          -- SET IsDeleted = 1                                   -            
                                        -- WHERE id =6 ;



--insert into Author (IsDeleted) Values (0)
--ALTER TABLE Author
--    ALTER COLUMN IsDeleted BIT
--    DEFAULT 0 NOT NULL;



--ALTER TABLE Author
--DROP COLUMN IsDeleted;
    --ADD IsReal BIT
    --DEFAULT 0 NOT NULL;

    ALTER TABLE Blog
    ADD IsDeleted BIT
    DEFAULT 0 NOT NULL;
select * from Blog;