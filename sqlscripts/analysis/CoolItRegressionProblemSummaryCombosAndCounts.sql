drop table #MultipleOuputs
GO
create table #MultipleOuputs(
problemId int,
coolerId int,
materialId int,
length float,
crossSection float,
powerFactor float,
inputPower1 float,
cost1 float,
stressLimit1 float,
Temperature1 float,
IsValidSolution1 bit,
inputPower2 float, 
cost2 float, 
stressLimit2 float, 
Temperature2 float, 
IsValidSolution2 bit
)

insert into #MultipleOuputs
--Get all the different combinations on inputs and the associated outputs
--exclude the first record in any episode because we already know we have issues there
select distinct
e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution,
s2.inputPower, s2.cost, s2.stressLimit, s2.Temperature, s2.IsValidSolution
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
--limit to after code has stabelized
and s1.timestamp > '4/1/2009'
and s2.timestamp > '4/1/2009'
--exclude the first record of every episode
and s1.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
and s2.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
and (s1.inputPower <> s2.inputPower OR s1.Cost <> s2.Cost OR s1.stressLimit <> s2.stressLimit
OR s1.Temperature <> s2.Temperature OR s1.IsValidSolution <> s2.isValidSolution)
order by e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution

select count(s2.id), s1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
inputPower1, cost1, stressLimit1, Temperature1, IsValidSolution1 from #MultipleOuputs s1
inner join States as s2 on
s1.materialId = s2.materialId
and s1.length = s2.length
and s1.crossSection = s2.crossSection
and s1.materialId = s2.materialId
and s1.powerFactor = s2.powerFactor
and s1.coolerId = s2.coolerId
and s1.inputPower1 = s2.inputPower
and s1.stressLimit1 =s2.stressLimit
and s1.cost1 = s2.cost
and s1.temperature1 = s2.temperature
and s1.IsValidSolution1 = s2.IsValidSolution
and s2.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
group by problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
inputPower1, cost1, stressLimit1, Temperature1, IsValidSolution1
order by problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
inputPower1, cost1, stressLimit1, Temperature1, IsValidSolution1