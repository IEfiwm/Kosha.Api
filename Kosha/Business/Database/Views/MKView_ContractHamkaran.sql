USE [Sabzzivar_sg3]
GO

CREATE VIEW [dbo].[MKView_ContractHamkaran]
 
AS

select  

          EMP.Code AS [کد پرسنلی], [30].FirstName AS نام, [30].LastName AS [نام خانوادگی],[30].FatherName AS [نام پدر]
         ,[100].Title AS [پروژه],[100].EmploymentTypeID AS [کد پروژه]
		 ,[101].Title AS [شغل]
		 ,[30].NationalID AS [کد ملی]
		 , [30].IDNumber AS [شماره شناسنامه],'' as [محل صدور],'' as [آخرین مدرک و رشته تحصیلی],N'انجام شده' as [وضعیت سربازی]
         ,[30].BirthDate AS [تاریخ تولد],CAST(getdate() AS date) as [تاریخ شروع قرارداد],CAST(getdate() AS date) as
		 [تاریخ پایان قرارداد]
		 ,'' as [مدت قرارداد]
		 ,[99].EmployeeStatuteID

         ,value1 AS [حقوق پایه],value2 AS [حق مسکن],value3 AS [بن کارگری],value4 AS [حق اولاد],value5 AS [پایه ثنوات]

 

FROM                  (SELECT     ESF.Value AS value1 ,esf.EmployeeStatuteRef ,[99].EmployeeRef,esf.EmployeeStatuteFactorID as ESF1
 
                       FROM         [HCM3].[EmployeeStatuteFactor] AS ESF INNER JOIN
 
                                               [HCM3].[EmployeeStatute] AS [99] ON [99].EmployeeStatuteID = ESF.EmployeeStatuteRef  INNER JOIN
 
                                              [HCM3].[StatuteFactorProperty] AS SFP ON SFP.StatuteFactorPropertyID = ESF.StatuteFactorPropertyRef AND SFP.StatuteFactorRef = 3
 
                       GROUP BY ESF.Value,esf.EmployeeStatuteRef ,[99].EmployeeRef,esf.EmployeeStatuteFactorID,[99].EmployeeStatuteID
                        ) AS [1] LEFT OUTER JOIN
 
                          (SELECT     ESF.Value AS value2 ,esf.EmployeeStatuteRef,[99].EmployeeRef
                          
                                       FROM         [HCM3].[EmployeeStatuteFactor] AS ESF INNER JOIN
 
                              [HCM3].[EmployeeStatute] AS [99] ON ESF.EmployeeStatuteRef = [99].EmployeeStatuteID INNER JOIN
 
                              [HCM3].[StatuteFactorProperty] AS SFP ON SFP.StatuteFactorPropertyID = ESF.StatuteFactorPropertyRef AND SFP.StatuteFactorRef = 16
 
                         GROUP BY ESF.Value,esf.EmployeeStatuteRef ,[99].EmployeeRef) AS [2] ON [1].EmployeeStatuteRef  = [2].EmployeeStatuteRef 

                          LEFT OUTER JOIN
 
                          (SELECT     ESF.Value AS value3 ,esf.EmployeeStatuteRef,[99].EmployeeRef
                          
                                       FROM         [HCM3].[EmployeeStatuteFactor] AS ESF INNER JOIN
 
                              [HCM3].[EmployeeStatute] AS [99] ON ESF.EmployeeStatuteRef = [99].EmployeeStatuteID INNER JOIN
 
                              [HCM3].[StatuteFactorProperty] AS SFP ON SFP.StatuteFactorPropertyID = ESF.StatuteFactorPropertyRef AND SFP.StatuteFactorRef = 17
 
                         GROUP BY ESF.Value,esf.EmployeeStatuteRef ,[99].EmployeeRef) AS [3] ON [1].EmployeeStatuteRef  = [3].EmployeeStatuteRef 

                          LEFT OUTER JOIN
 
                          (SELECT     ESF.Value AS value4 ,esf.EmployeeStatuteRef,[99].EmployeeRef
                          
                                       FROM         [HCM3].[EmployeeStatuteFactor] AS ESF INNER JOIN
 
                              [HCM3].[EmployeeStatute] AS [99] ON ESF.EmployeeStatuteRef = [99].EmployeeStatuteID INNER JOIN
 
                              [HCM3].[StatuteFactorProperty] AS SFP ON SFP.StatuteFactorPropertyID = ESF.StatuteFactorPropertyRef AND SFP.StatuteFactorRef = 15
 
                         GROUP BY ESF.Value,esf.EmployeeStatuteRef ,[99].EmployeeRef) AS [4] ON [1].EmployeeStatuteRef  = [4].EmployeeStatuteRef 
                          LEFT OUTER JOIN
 
                          (SELECT     ESF.Value AS value5 ,esf.EmployeeStatuteRef,[99].EmployeeRef
                          
                                       FROM         [HCM3].[EmployeeStatuteFactor] AS ESF INNER JOIN
 
                              [HCM3].[EmployeeStatute] AS [99] ON ESF.EmployeeStatuteRef = [99].EmployeeStatuteID INNER JOIN
 
                              [HCM3].[StatuteFactorProperty] AS SFP ON SFP.StatuteFactorPropertyID = ESF.StatuteFactorPropertyRef AND SFP.StatuteFactorRef = 155
 
                         GROUP BY ESF.Value,esf.EmployeeStatuteRef ,[99].EmployeeRef) AS [5] ON [1].EmployeeStatuteRef  = [5].EmployeeStatuteRef 



                       INNER JOIN
                       [HCM3].[Employee]as emp ON EMP.EmployeeID = [1].EmployeeRef 
                       INNER JOIN
                       GNR3.Party AS [30] ON EMP.PartyRef = [30].PartyID 
                       INNER JOIN
                       [HCM3].[EmployeeStatute] AS [99] ON EMP.EmployeeID = [99].EmployeeRef 
                        and  [1].EmployeeStatuteRef = [99].EmployeeStatuteID 

                       INNER JOIN 
                       [HCM3].[EmployeeStatuteFactor] AS ESF ON ESF.EmployeeStatuteRef = [99].EmployeeStatuteID 
                       
                       
                     
             
                       INNER JOIN

                       [HCM3].[EmploymentType] AS [100] ON [99].EmploymentTypeRef = [100].EmploymentTypeID LEFT OUTER JOIN
                       [HCM3].[Job] AS [101] ON [99].JobRef = [101].JobID

                       
                       
                       
     GROUP BY EMP.Code , [30].FirstName , [30].LastName  ,[30].FatherName ,
     [100].Title  ,[100].EmploymentTypeID  ,[101].Title  ,[30].NationalID  , [30].IDNumber  ,
     [30].BirthDate ,[99].EmployeeStatuteID,
     value1,value2,value3,value4,value5
     
     --ORDER BY EmployeeStatuteID DESC
     




GO


