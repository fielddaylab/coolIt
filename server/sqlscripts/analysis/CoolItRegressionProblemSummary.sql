--get the count of records with the same input and a different output
select count(s2.id) as TotalProblems, s1.id, s1.timestamp
from States s1
inner join States s2 on s1.length = s2.length
inner join Episodes e1 on s1.episodeId = e1.id
inner join Episodes e2 on s2.episodeId = e2.id
where s1.crossSection = s2.crossSection
and s1.materialId = s2.materialId
and s1.powerFactor = s2.powerFactor
and s1.coolerId = s2.coolerId
and e1.problemId = e2.problemId
and s1.id <> s2.id
and s1.inputPower != 0
and s1.stressLimit != 0
and s2.inputPower != 0
and s2.stressLimit != 0
and (s1.inputPower <> s2.inputPower OR s1.Cost <> s2.Cost OR s1.stressLimit <> s2.stressLimit
OR s1.Temperature <> s2.Temperature OR s1.IsValidSolution <> s2.isValidSolution)
group by s1.id, s1.timestamp
order by TotalProblems desc