
select * from post p
left join blog b on p.blogId = b.id
where b.Id = 8
;