--Get the different combinations of inputs
select distinct
e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor
from States s1
inner join Episodes e1 on s1.episodeId = e1.id
order by e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor

--review records with a specific input
select *
from States s1
inner join Episodes e1 on s1.episodeId = e1.id
where problemId = 1
and coolerId = 1
and materialId = 2
and length = 0.064
and crossSection = 0.001
and powerFactor = 1
order by s1.id