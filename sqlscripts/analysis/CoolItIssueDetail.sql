--review records with a specific input
select *
from States s1
inner join Episodes e1 on s1.episodeId = e1.id
where problemId = 1
and coolerId = 3
and materialId = 11
and length = 0.5
and crossSection = 0.001
and powerFactor = 1
order by s1.id

--review records with a specific episode number
select *
from States
where EpisodeId in (628)
order by id