--Number of Episodes by UserID an Email
select count(e.id) as EpisodeCount, userId, email
from Episodes e
inner join Users u
on u.id = e.UserId
where e.id in (
select distinct e.id from Episodes e inner join States s on s.episodeId = e.id
where 
--Class
((timestamp > '3/30/2009'
and timestamp < '4/7/2010') OR
--Short Course
(timestamp > '6/27/2009' and timestamp < '7/3/2009') OR
--China
(timestamp > '10/29/2009' and timestamp < '11/3/2009') OR
--Experts
timestamp > '3/21/2010') and email not like 'Anonymous%')
group by userId, email
order by EpisodeCount desc, email

--Check range of game play within a specific date range
select min(timestamp), max(timestamp)
from States
where timestamp > '3/20/2010'
and timestamp < '5/1/2010'

--See detail of sim play within a specific date range
select s.id, c.name as CoolerName, m.Name as MaterialName,
s.length * 100 as LengthMeters, s.crossSection * 10000 as CrossSectionSquareMeters, 
s.powerFactor, s.inputPower,
s.cost, s.stressLimit, 
s.temperature, s.isValidSolution, 
p.name as ProblemName, s.timestamp, e.id, 
e.userId, e.problemId, u.email
from States s
INNER JOIN Episodes e ON e.id = s.episodeId
INNER JOIN Users u ON u.id = e.userId
INNER JOIN Coolers c on s.coolerId = c.id
INNER JOIN Materials m on m.id = s.materialId
INNER JOIN Problems p on p.id = e.problemId
where timestamp > '6/1/2009'
and timestamp < '7/1/2009'
order by s.id
