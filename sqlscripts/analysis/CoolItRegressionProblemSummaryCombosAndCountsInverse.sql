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
IsValidSolution1 bit
)

insert into #MultipleOuputs
--Get all the different combinations on inputs and the associated outputs
select distinct
e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution
from States s1
inner join States s2 on s1.length = s2.length
inner join Episodes e1 on s1.episodeId = e1.id
inner join Episodes e2 on s2.episodeId = e2.id
where s1.crossSection = s2.crossSection
and e1.problemId = e2.problemId
and s1.materialId = s2.materialId
and s1.powerFactor = s2.powerFactor
and s1.coolerId = s2.coolerId
and e1.problemId = e2.problemId
and s1.id <> s2.id
and s1.timestamp > '4/1/2009'
and s2.timestamp > '4/1/2009'
and (s1.inputPower <> s2.inputPower OR s1.Cost <> s2.Cost OR s1.stressLimit <> s2.stressLimit
OR s1.Temperature <> s2.Temperature OR s1.IsValidSolution <> s2.isValidSolution)
order by e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution

select count(s2.id) as RecordCount, s1.* from #MultipleOuputs s1
inner join States as s2 on
s1.materialId = s2.materialId
inner join Episodes e on e.id = s2.episodeId
where s1.length = s2.length
and e.problemId = s1.problemId
and s1.crossSection = s2.crossSection
and s1.materialId = s2.materialId
and s1.powerFactor = s2.powerFactor
and s1.coolerId = s2.coolerId
and s1.inputPower1 = s2.inputPower
and s1.stressLimit1 =s2.stressLimit
and s1.cost1 = s2.cost
and s1.temperature1 = s2.temperature
and s1.IsValidSolution1 = s2.IsValidSolution

group by s1.problemId, s1.coolerId, s1.materialID, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower1, s1.cost1, s1.stressLimit1, s1.temperature1, s1.isValidSolution1
order by problemId, coolerId, materialId, length, crossSection, powerFactor,
inputPower1, cost1, stressLimit1, Temperature1, IsValidSolution1