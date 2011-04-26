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
select distinct
e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution,
s2.inputPower, s2.cost, s2.stressLimit, s2.Temperature, s2.IsValidSolution
from States s1
inner join States s2 on s1.length = s2.length
inner join Episodes e1 on s1.episodeId = e1.id
inner join Episodes e2 on s2.episodeId = e2.id
inner join States prev on s1.id = (prev.id -1)
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
and prev.episodeId = s1.episodeId
and (s1.inputPower <> s2.inputPower OR s1.Cost <> s2.Cost OR s1.stressLimit <> s2.stressLimit
OR s1.Temperature <> s2.Temperature OR s1.IsValidSolution <> s2.isValidSolution)
order by e1.problemId, s1.coolerId, s1.materialId, s1.length, s1.crossSection, s1.powerFactor,
s1.inputPower, s1.cost, s1.stressLimit, s1.Temperature, s1.IsValidSolution
