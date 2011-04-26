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
where s.episodeId = (select episodeId from States where id = @id)
order by id