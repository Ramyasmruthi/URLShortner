# URLShortner

Created ASP.NET MVC project for generating the URL shortner.

Generated a random code and used to generate the shortest possible URL.



Database Details
----------------

Database is SQL Server. So backup Database and related sql scripts are provided in Database Folder.

Implemented Archiving 'URLDetails' table to handle the traffic.

Included Script 'ArchiveURLDetailsJob' used to create job in SQL Server Agent.

Included Stored proc script 'SP_ArchiveURLDetails' to archive the old data from URLDetails to ARC_URLDetails.


