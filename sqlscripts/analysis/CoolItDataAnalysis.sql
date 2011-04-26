--Data export for analysis project
select s.id as StateID, e.id as EpisodeId, c.name as CoolerName, m.name as MaterialName, 
length,
--length * 100 as LengthMeters,
crossSection,
--crossSection * 10000 as CrossSectionMeters, 
powerFactor, inputPower, s.cost, 
stressLimit, temperature, isValidSolution, s.timestamp, 
isOpen, userId, 
u.email, ut.userTypeId as UserTypeId, ut.Name as UserType,
p.*
from States s
inner join Episodes e on e.id = s.episodeId
inner join Coolers c on c.id = s.coolerId
inner join Materials m on m.id = s.materialId
inner join Problems p on p.id = e.problemId
inner join Users u on e.userId = u.id
inner join UserType ut on ut.userTypeId = u.userType
where 
--Class
((timestamp > '3/30/2009'
and timestamp < '4/7/2010') OR
--Short Course
(timestamp > '6/27/2009' and timestamp < '7/3/2009') OR
--China
(timestamp > '10/29/2009' and timestamp < '11/3/2009') OR
--Experts
timestamp > '3/21/2010') 
--only experts, students and industry people
and userTypeId > 0
--exclude the first record of every episode
and s.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
--anomalous record ids
and s.id not in(23444,82396,117242,124438,99971,120491,10503,30625,74947,75028)
--exclude records where the length slider is simply in a middle change state 
--defined as < 2 seconds by Josh and Lindsey
and s.id not in(
select curr.id
--, curr.timestamp, curr.length, prev.id, prev.timestamp, prev.length, next.id, next.timestamp, next.length
from States curr
inner join States prev on prev.id = (curr.id - 1)
inner join States next on next.id = (curr.id + 1)
and curr.length != prev.length
and curr.length != next.length
and curr.timestamp < dateadd(ss, 2, prev.timestamp)
and next.timestamp < dateadd(ss, 2, curr.timestamp)
--previous record shouldn't be the first record of the episode
and prev.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
)
--exclude records where the cross section slider is simply in a middle change state 
--defined as < 2 seconds by Josh and Lindsey
and s.id not in(
select curr.id
--, curr.timestamp, curr.length, prev.id, prev.timestamp, prev.length, next.id, next.timestamp, next.length
from States curr
inner join States prev on prev.id = (curr.id - 1)
inner join States next on next.id = (curr.id + 1)
and curr.crossSection != prev.crossSection
and curr.crossSection != next.crossSection
and curr.timestamp < dateadd(ss, 2, prev.timestamp)
and next.timestamp < dateadd(ss, 2, curr.timestamp)
--previous record shouldn't be the first record of the episode
and prev.id not in (select next.id
from States curr
inner join States next on curr.id = (next.id - 1)
and next.episodeId <> curr.episodeId)
)
order by EpisodeId, s.id


