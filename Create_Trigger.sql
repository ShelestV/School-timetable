create trigger Insert_Study_Plan
on Study_Plan
after insert
as 
update Classes_Loading set Year_loading = (select sum(Study_Plan.Year_loading) 
										   from Study_Plan
										   where Study_Plan.Study_year = Classes_Loading.Study_year);

