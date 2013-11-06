--Compare records in the old and new state management databases with the same input as a given record
declare @id as int
set @id = 82396

select s.id, c.name as CoolerName, m.Name as MaterialName,
s.length * 100 as LengthMeters, s.crossSection * 10000 as CrossSectionSquareMeters, 
s.powerFactor, s.inputPower,
s.cost, s.stressLimit, 
s.temperature, s.isValidSolution, 
p.name as ProblemName, s.timestamp, e.isopen, 
e.userId, e.problemId, u.email
from States s
INNER JOIN Episodes e ON e.id = s.episodeId
INNER JOIN Users u ON u.id = e.userId
INNER JOIN Coolers c on s.coolerId = c.id
INNER JOIN Materials m on m.id = s.materialId
INNER JOIN Problems p on p.id = e.problemId
where s.id = @id

select new.id, c.name as CoolerName, m.Name as MaterialName,
new.length * 100, new.crossSection * 10000, 
new.powerFactor, new.inputPower,
new.cost, new.stressLimit, 
new.temperature, new.isValidSolution, 
p.name as ProblemName, new.timestamp, e.isopen, 
e.userId, e.problemId, u.email
from States orig
INNER JOIN Episodes oe on oe.id = orig.episodeId,
States new
INNER JOIN Episodes e ON e.id = new.episodeId
INNER JOIN Users u ON u.id = e.userId
INNER JOIN Coolers c on new.coolerId = c.id
INNER JOIN Materials m on m.id = new.materialId
INNER JOIN Problems p on p.id = e.problemId
where orig.id = @id
and orig.length = new.length
and orig.crossSection = new.crossSection
and orig.materialId = new.materialId
and orig.powerFactor = new.powerFactor
and orig.coolerId = new.coolerId
and oe.problemId = e.problemId
and orig.id != new.id
order by new.id

select nps.id, c.name as CoolerName, m.Name as MaterialName,
nss.length * 100, nss.crossSection * 10000, 
nps.powerFactor, ncs.inputPower,
nps.cost, nps.stressLimit, 
nps.temperature, nps.isValidSolution, 
p.name as ProblemName, nps.timestamp, e.isopen, 
e.userId, e.problemId, u.email
from CoolIt2.dbo.States orig
inner join CoolIt2.dbo.Episodes oe on orig.episodeId = oe.id
inner join CoolIt2.dbo.ProblemStates nps on nps.powerFactor = orig.powerFactor
inner join CoolIt2.dbo.StrutStates nss on nss.problemStateId = nps.id
inner join CoolIt2.dbo.CoolerStates ncs on ncs.problemStateId = nps.id
inner join CoolIt2.dbo.Coolers c on ncs.coolerId = c.id
inner join CoolIt2.dbo.Materials m on nss.materialId = m.id
inner join CoolIt2.dbo.Episodes e on e.id = nps.episodeId
inner join CoolIt2.dbo.Problems p on e.problemId = p.id
inner join CoolIt2.dbo.Users u on u.id = e.userId
where  orig.id = @id
and orig.length = nss.length
and orig.crossSection = nss.crossSection
and orig.materialId = nss.materialId
and orig.powerFactor = nps.powerFactor
and orig.coolerId = ncs.coolerId
and oe.problemId = e.problemId
and orig.id != nps.id
order by nps.id