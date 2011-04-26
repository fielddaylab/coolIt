select s.id, c.name as CoolerName, m.name as MaterialName, length * 100 as LengthMeters,
crossSection * 10000 as CrossSectionMeters, powerFactor, inputPower, s.cost, 
stressLimit, temperature, isValidSolution, p.name as ProblemName, s.timestamp, 
isOpen, userId, problemId,
u.email
from States s
inner join Episodes e on e.id = s.episodeId
inner join Coolers c on c.id = s.coolerId
inner join Materials m on m.id = s.materialId
inner join Problems p on p.id = e.problemId
inner join Users u on e.userId = u.id
--where problemId = 6
--and isValidSolution = 0
--and s.TimeStamp > '3/29/2009'
--and s.TimeStamp < '4/18/2009'
--and inputPower != 0
--and stressLimit != 0
where s.id = 21810
order by s.cost desc