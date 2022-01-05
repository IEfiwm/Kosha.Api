USE [Sabzzivar_sg3]
GO

/****** Object:  View [dbo].[MKView_FishHamkaran]    Script Date: 7/13/2020 4:34:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [dbo].[MKView_FishHamkaran]
 
AS
 
SELECT
ISNULL([1].value1, 0) AS [کارکرد موثر], 
ISNULL([54].value54, 0) AS [کارکرد اضافه کاری], 
ISNULL([55].value55, 0) AS [کارکرد تعطیل کاری],
ISNULL([26].value26, 0) AS [جمعه کاری],
ISNULL([41].value41, 0) AS [کارکرد شبکاری],
ISNULL([57].value57, 0) AS [کارکرد شب کاری 1],
ISNULL([39].value39, 0) AS [کارکرد مرخصی استحقاقی],
ISNULL([50].value50, 0) AS [کارکرد کارانه],
ISNULL([114].value114, 0) AS [کارکرد_کارانه 2],
ISNULL([12].value12, 0) AS [کارکرد کارانه2],
ISNULL([25].value25, 0) AS [کارکرد ساعتی],
ISNULL([112].value112, 0) AS [جمع کارکرد سال],
ISNULL([73].value73, 0) AS [پایه سنوات],
ISNULL([2].value2, 0) AS [حقوق پایه],
ISNULL([6].value6, 0) AS [حق اولاد],
ISNULL([19].value19, 0) AS [حق اولاد معوق],
ISNULL([4].value4, 0) AS [حق مسکن],
ISNULL([8].value8, 0) AS [بن کارگری],
ISNULL([5].value5, 0) AS [حق خواربار], 
ISNULL([3].value3, 0) AS [اضافه کاری],
ISNULL([7].value7, 0) AS [تعطیل کاری],
ISNULL([14].value14, 0) AS [شبکاری],
ISNULL([11].value11, 0) AS [حق شیر],
ISNULL([9].value9, 0) AS [شیفت],
ISNULL([15].value15, 0) AS [شیفت ساعتی],
ISNULL([45].value45, 0) AS [مبلغ تناژ],
ISNULL([42].value42, 0) AS [تنخواه],
ISNULL([62].value62, 0) AS [حق سوخت],
ISNULL([35].value35, 0) AS [ماموریت],
ISNULL([43].value43, 0) AS [فوق العاده ماموریت],
ISNULL([69].value69, 0) AS [فوق العاده سرپرستی],
ISNULL([47].value47, 0) AS [کارانه],
ISNULL([63].value63, 0) AS [کارانه ثابت],
ISNULL([64].value64, 0) AS [کارانه ثابت2],
isnull([115].value115,0) as [کارانه 2],
isnull([116].value116,0) as [خالص حقوق],
isnull([117].value117,0) as [حق ناهار],
isnull([118].value118,0) as [گروه شغلی],
ISNULL([49].value49, 0) AS [سایر مزایا],
ISNULL([77].value77, 0) AS [بیمه تکمیلی سازمانی کارمند],
ISNULL([78].value78, 0) AS [بیمه تکمیلی سازمانی],
ISNULL([60].value60, 0) AS [مزایای معوقه],
ISNULL([22].value22, 0) AS [کارانه معوق],
ISNULL([36].value36, 0) AS [فوق العاده شغل], 
ISNULL([10].value10, 0) AS [پاداش پرسنل],
ISNULL([40].value40, 0) AS [ایاب و ذهاب], 
ISNULL([20].value20, 0) AS [معوقه حقوق],
ISNULL([51].value51, 0) AS [بن رمضان],
ISNULL([61].value61, 0) AS [هزینه جارو],
ISNULL([66].value66, 0) AS [پایه سنوات معوق],
ISNULL([59].value59, 0) AS [سایر مزایای استیجاری],
ISNULL([46].value46, 0) AS [بدهکاران کارکنان], 
ISNULL([16].value16, 0) AS [بیمه تامین اجتماعی سهم کارگر],
ISNULL([17].value17, 0) AS [بیمه تکمیلی سهم کارمند],
ISNULL([68].value68, 0) AS [سایر کسور], 
ISNULL([72].value72, 0) AS [خسارت کارکنان],
ISNULL([48].value48, 0) AS [کارکنان بدهکار],
ISNULL([21].value21, 0) AS [مساعده],
ISNULL([65].value65, 0) AS [تعهدات دولتی کارمند],
ISNULL([18].value18, 0) AS [جمع اقساط وام],
ISNULL([67].value67, 0) AS [تعاونی مصرف کارکنان],
ISNULL([70].value70, 0) AS [مالیات حقوق], 
ISNULL([13].value13, 0) AS [جمع مزایا],
ISNULL([23].value23, 0) AS [جمع کسور],
ISNULL([24].value24, 0) AS [خالص پرداختی], 
ISNULL([113].value113,0) as [تعطیل کاری دستور کار],
ISNULL([119].value119,0) as [مزد ماهانه],
ISNULL([120].value120,0) as NightWorking, --[کارکرد_شبکاری_روز],
ISNULL([121].value121,0) as  HolidayWorking, -- [کارکرد-تعطیل کاری-روز],
ISNULL([122].value122,0) as [کارکرد_اضافه کاری],
ISNULL([123].value123,0) as [بیمه تکمیلی],
ISNULL([124].value124,0) as [قسط وام مسکن],
ISNULL([125].value125,0) as [مزد روزانه],
ISNULL([126].value126,0) as [تعهدات دولتی],
ISNULL([127].value127, 0) AS [دستمزد روزانه], 
ISNULL([128].value128, 0) AS [دستمزد ماهانه], 
ISNULL([129].value129, 0) AS [مالیات], 
ISNULL([130].value130, 0) AS [قابل پرداخت], 

EPL.AccountNumber AS [شماره حساب], 
[30].FirstName AS [نام],
[30].LastName AS [نام خانوادگی],
EMP.Code AS [کد پرسنلی],
[30].FatherName AS [نام پدر],
[30].NationalID AS [کد ملی], 
[30].IDNumber AS [شماره شناسنامه],
[30].BirthDate AS [تاریخ تولد],
[38].Title AS [نام شعبه],
SUBSTRING(CAST([1].IssueYearMonth AS nvarchar), 1, 4) AS سال, 
SUBSTRING(CAST([1].IssueYearMonth AS nvarchar), 5, 2) AS ماه,
--[31].Code AS [شماره بیمه],
ISNULL([111].value111, 0) AS [کارکرد عادی], 
--ISNULL(SUM([9].value9), 0) AS [پاداش], 
ISNULL([12].value12, 0) AS [تعداد اولاد]
--ISNULL(SUM([15].value15), 0) AS مالیات, 
--ISNULL(SUM([16].value16), 0) AS [بیمه تامین اجتماعی سهم کارمند],
--ISNULL(SUM([20].value20), 0) AS [فوق العاده جذب], 
--ISNULL(SUM([22].value22), 0) AS [فوق العاده کارایی], 
--ISNULL(SUM([25].value25), 0) AS [معوقه دستی ], 
--ISNULL(SUM([26].value26), 0) AS [بیمه تامین اجتماعی سهم کارفرما], 
--ISNULL(SUM([27].value27), 0) AS [بیمه بیکاری ], 
--ISNULL(SUM([28].value28), 0) AS [بیمه تکمیلی سهم کارفرما], 
--ISNULL(SUM([34].value34), 0) AS [معوقه دستی با مالیات], 
--ISNULL(SUM([35].value35), 0) AS [فوق العاده خلاقیت], 
--ISNULL(SUM([39].value39), 0) AS [فوق العاده پست ], 
--ISNULL(SUM([40].value40), 0) AS [حق ایاب و ذهاب], 
--ISNULL(SUM([41].value41), 0) AS [فوق العاده منزلت], 
--ISNULL(SUM([42].value42), 0) AS [ماموریت عادی], 
--ISNULL(SUM([43].value43), 0) AS [ماموریت روز تعلیل], 
--ISNULL(SUM([44].value44), 0) AS [ماموریت حومه], 
--ISNULL(SUM([45].value45), 0) AS [حق غذای ماموریت حومه], 
--ISNULL(SUM([46].value46), 0) AS [احضار به کار پایین تر از 5 س], 
--ISNULL(SUM([47].value47), 0) AS [احضار به کار بین 5 تا 10 س],
--ISNULL(SUM([48].value48), 0) AS [احضار به کار بالاتر از 10 س], 
--ISNULL(SUM([49].value49), 0) AS [هزینه موبایل], 
--ISNULL(SUM([50].value50), 0) AS [کسر کار], 
--ISNULL(SUM([51].value51), 0) AS [حقوق گروه مشاور], 
--ISNULL(SUM([52].value52), 0) AS [حقوق گروه ساعتی], 
,ISNULL([53].value53, 0) AS [غیبت ماهانه]
--ISNULL(SUM([66].value66), 0) AS [احضار به کار پایین تر از 5س], 
--ISNULL(SUM([67].value67), 0) AS [احضار به کار بین 5 تا 10س], 
--ISNULL(SUM([69].value69), 0) AS [سایر2], 
--ISNULL(SUM([70].value70), 0) AS [روند حقوق],
--ISNULL(SUM([58].value58), 0) AS [کارکرد شب کاری],
--ISNULL(SUM([59].value59), 0) AS [سایر3], 
--ISNULL(SUM([60].value60), 0) AS [سایر1], 
--ISNULL(SUM([61].value61), 0) AS [نوبت کاری 10 %],
--ISNULL(SUM([62].value62), 0) AS [ماموریت عادی نهایی], 
--ISNULL(SUM([63].value63), 0) AS [ماموریت تعلیل نهایی], 
--ISNULL(SUM([64].value64), 0) AS [کارکرد ماموریت حومه نهایی], 
--ISNULL(SUM([65].value65), 0) AS [فوق العاده در دسترسی نهایی]
FROM         
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value1, 
PC.IssueYearMonth,
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'Effectwork'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [1] 
LEFT OUTER JOIN
(
SELECT     
C.Title,
SUM(PCI.Value) AS value2, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'Basepay'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [2] 
ON 
[1].IssueYearMonth = [2].IssueYearMonth 
AND 
[1].EmployeeRef = [2].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value3, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'ExtraworkPay'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [3] 
ON 
[1].IssueYearMonth = [3].IssueYearMonth 
AND 
[1].EmployeeRef = [3].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value4, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'Housepay' 
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [4] 
ON 
[1].IssueYearMonth = [4].IssueYearMonth 
AND  
[1].EmployeeRef = [4].EmployeeRef 
LEFT OUTER JOIN
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value5, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'HagheKharbar'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [5] 
ON 
[1].IssueYearMonth = [5].IssueYearMonth 
AND 
[1].EmployeeRef = [5].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value6, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'ChildPay'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [6] 
ON 
[1].IssueYearMonth = [6].IssueYearMonth 
AND 
[1].EmployeeRef = [6].EmployeeRef 
LEFT OUTER JOIN  
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value73, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'PayeSanavat'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [73] 
ON 
[1].IssueYearMonth = [73].IssueYearMonth 
AND 
[1].EmployeeRef = [73].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value7, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'HolidayPay'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [7] 
ON 
[1].IssueYearMonth = [7].IssueYearMonth 
AND 
[1].EmployeeRef = [7].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value8, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'GrubPay'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [8] 
ON 
[1].IssueYearMonth = [8].IssueYearMonth 
AND 
[1].EmployeeRef = [8].EmployeeRef 
LEFT OUTER JOIN
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value9, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'Shift'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [9] 
ON 
[1].IssueYearMonth = [9].IssueYearMonth 
AND 
[1].EmployeeRef = [9].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value10, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'PadashePersonel'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [10] 
ON 
[1].IssueYearMonth = [10].IssueYearMonth 
AND 
[1].EmployeeRef = [10].EmployeeRef 
LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value11, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'HagheShir'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [11] 
ON [1].IssueYearMonth = [11].IssueYearMonth AND 
 
[1].EmployeeRef = [11].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value12, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'TedadOlad'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [12] ON [1].IssueYearMonth = [12].IssueYearMonth AND 
 
[1].EmployeeRef = [12].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value13, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'BonusSum'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [13] ON [1].IssueYearMonth = [13].IssueYearMonth AND 
 
[1].EmployeeRef = [13].EmployeeRef LEFT OUTER JOIN
 
(SELECT  C.Title, SUM(PCI.Value) AS value14, PC.IssueYearMonth, PC.EmployeeRef
 
FROM HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'NightPay'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [14] ON [1].IssueYearMonth = [14].IssueYearMonth AND 
 
[1].EmployeeRef = [14].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value15, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'ShiftSati'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [15] 
ON [1].IssueYearMonth = [15].IssueYearMonth AND 
 
[1].EmployeeRef = [15].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value16, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'EmployeeMainInsurance'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [16] 
ON [1].IssueYearMonth = [16].IssueYearMonth AND 
 
[1].EmployeeRef = [16].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value17, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'EmployeeSupplementalInsurance'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [17] 
ON [1].IssueYearMonth = [17].IssueYearMonth AND 
 
[1].EmployeeRef = [17].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value18, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID
 AND C.Name = 'LoanSum'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [18] 
ON [1].IssueYearMonth = [18].IssueYearMonth AND 
 
[1].EmployeeRef = [18].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value19, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF354'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [19] 
ON [1].IssueYearMonth = [19].IssueYearMonth AND 
 
[1].EmployeeRef = [19].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value20, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'mandeh'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [20] 
ON [1].IssueYearMonth = [20].IssueYearMonth AND 
 
[1].EmployeeRef = [20].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value21, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'Advancemoney'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [21] 
ON [1].IssueYearMonth = [21].IssueYearMonth AND 

[1].EmployeeRef = [21].EmployeeRef 
LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value22, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF363'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [22] ON [1].IssueYearMonth = [22].IssueYearMonth AND 
 
[1].EmployeeRef = [22].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value23, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'DeductSum'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [23] ON [1].IssueYearMonth = [23].IssueYearMonth AND 
 
[1].EmployeeRef = [23].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value24, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'NetPay'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [24] ON [1].IssueYearMonth = [24].IssueYearMonth AND 
 
[1].EmployeeRef = [24].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value25, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF305'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [25] ON [1].IssueYearMonth = [25].IssueYearMonth AND 
 
[1].EmployeeRef = [25].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value26, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'jomekari'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [26] ON [1].IssueYearMonth = [26].IssueYearMonth AND 
 
[1].EmployeeRef = [26].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value27, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'EmploymentInsurance'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [27] ON [1].IssueYearMonth = [27].IssueYearMonth AND 
 
[1].EmployeeRef = [27].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value28, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'BossSupplementalInsurance'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [28] ON [1].IssueYearMonth = [28].IssueYearMonth AND 
 
[1].EmployeeRef = [28].EmployeeRef INNER JOIN
 
HCM3.Employee AS EMP ON [1].EmployeeRef = EMP.EmployeeID LEFT OUTER JOIN
 
GNR3.Party AS [30] ON EMP.PartyRef = [30].PartyID INNER JOIN
 
HCM3.EmployeeRelatedOrganization AS [31] ON EMP.EmployeeID = [31].EmployeeRef INNER JOIN
 
HCM3.OrganizationBranch AS [32] ON [31].OrganizationBranchRef = [32].OrganizationBranchID INNER JOIN
 
HCM3.Organization AS [33] ON [32].OrganizationRef = [33].OrganizationID LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value34, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF126'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [34] ON [1].IssueYearMonth = [34].IssueYearMonth AND 
 
[1].EmployeeRef = [34].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value35, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'Mamoriat'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [35] 
ON [1].IssueYearMonth = [35].IssueYearMonth AND 
 
[1].EmployeeRef = [35].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value36, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'fogh'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [36] 
ON [1].IssueYearMonth = [36].IssueYearMonth AND 
 
[1].EmployeeRef = [36].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value39, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF307'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [39] ON [1].IssueYearMonth = [39].IssueYearMonth AND 
 
[1].EmployeeRef = [39].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value40, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'TransportPay'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [40] ON [1].IssueYearMonth = [40].IssueYearMonth AND 
 
[1].EmployeeRef = [40].EmployeeRef LEFT OUTER JOIN
 
--(SELECT     C.Title, SUM(PCI.Value) AS value41, PC.IssueYearMonth, PC.EmployeeRef
 
--FROM          HCM3.PayCalc AS PC INNER JOIN
 
--HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
--HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF304'
 
--GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [41] ON [1].IssueYearMonth = [41].IssueYearMonth AND 
 
--[1].EmployeeRef = [41].EmployeeRef LEFT OUTER JOIN

 
(SELECT B.Title, SUM(A.Value) AS value41, A.ApplyYearMonth, AA.EmployeeRef
 
FROM HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID 

AND B.Name = 'NightPayTime'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [41] 

ON [1].IssueYearMonth = [41].ApplyYearMonth AND 
 
[1].EmployeeRef = [41].EmployeeRef LEFT OUTER JOIN


 
(SELECT  C.Title, SUM(PCI.Value) AS value42, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'TANKHAH'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [42] 

ON [1].IssueYearMonth = [42].IssueYearMonth AND 
 
[1].EmployeeRef = [42].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value43, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF356'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [43] ON [1].IssueYearMonth = [43].IssueYearMonth AND 
 
[1].EmployeeRef = [43].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value44, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF143'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [44] ON [1].IssueYearMonth = [44].IssueYearMonth AND 
 
[1].EmployeeRef = [44].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value45, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'MablaghTonaj'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [45] 
ON [1].IssueYearMonth = [45].IssueYearMonth AND 
 
[1].EmployeeRef = [45].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value46, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF348'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [46] ON [1].IssueYearMonth = [46].IssueYearMonth AND 
 
[1].EmployeeRef = [46].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value47, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF360'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [47] ON [1].IssueYearMonth = [47].IssueYearMonth AND 
 
[1].EmployeeRef = [47].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value48, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF359'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [48] ON [1].IssueYearMonth = [48].IssueYearMonth AND 
 
[1].EmployeeRef = [48].EmployeeRef LEFT OUTER JOIN
 
(SELECT C.Title, SUM(PCI.Value) AS value49, PC.IssueYearMonth, PC.EmployeeRef
 
FROM HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'Otherbenefit'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [49] 

ON [1].IssueYearMonth = [49].IssueYearMonth AND 
 
[1].EmployeeRef = [49].EmployeeRef LEFT OUTER JOIN
 
 
(SELECT  C.Title, SUM(PCI.Value) AS value115, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF366'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [115] 
ON [1].IssueYearMonth = [115].IssueYearMonth AND 
 
[1].EmployeeRef = [115].EmployeeRef 

LEFT OUTER JOIN

 
(SELECT  C.Title, SUM(PCI.Value) AS value116, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF344'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [116] 
ON [1].IssueYearMonth = [116].IssueYearMonth AND 
 
[1].EmployeeRef = [116].EmployeeRef 

LEFT OUTER JOIN

(SELECT     C.Title, SUM(PCI.Value) AS value50, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF367'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [50] 
ON [1].IssueYearMonth = [50].IssueYearMonth AND 
 
[1].EmployeeRef = [50].EmployeeRef 

LEFT OUTER JOIN


(SELECT     C.Title, SUM(PCI.Value) AS value114, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF368'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [114] 
ON [1].IssueYearMonth = [114].IssueYearMonth AND 
 
[1].EmployeeRef = [114].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value117, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF333'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [117] 
ON [1].IssueYearMonth = [117].IssueYearMonth AND 
 
[1].EmployeeRef = [117].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value118, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF327'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [118] 
ON [1].IssueYearMonth = [118].IssueYearMonth AND 
 
[1].EmployeeRef = [118].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value119, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF309'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [119] 
ON [1].IssueYearMonth = [119].IssueYearMonth AND 
 
[1].EmployeeRef = [119].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value120, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF306'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [120] 
ON [1].IssueYearMonth = [120].IssueYearMonth AND 
 
[1].EmployeeRef = [120].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value121, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF303'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [121] 
ON [1].IssueYearMonth = [121].IssueYearMonth AND 
 
[1].EmployeeRef = [121].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value122, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF302'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [122] 
ON [1].IssueYearMonth = [122].IssueYearMonth AND 
 
[1].EmployeeRef = [122].EmployeeRef 

LEFT OUTER JOIN

 
 
(SELECT C.Title, SUM(PCI.Value) AS value123, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'UF297'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [123] 
ON [1].IssueYearMonth = [123].IssueYearMonth AND 
 
[1].EmployeeRef = [123].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value124, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'HouseLoan'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [124] 
ON [1].IssueYearMonth = [124].IssueYearMonth AND 
 
[1].EmployeeRef = [124].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value125, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'DastMozdeRozane'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [125] 
ON [1].IssueYearMonth = [125].IssueYearMonth AND 
 
[1].EmployeeRef = [125].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value126, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 
AND C.Name = 'TahodateDolati'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [126] 
ON [1].IssueYearMonth = [126].IssueYearMonth AND 
 
[1].EmployeeRef = [126].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value127, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'Dailypayment'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [127] 

ON [1].IssueYearMonth = [127].IssueYearMonth AND 
 
[1].EmployeeRef = [127].EmployeeRef 

LEFT OUTER JOIN

(SELECT C.Title, SUM(PCI.Value) AS value128, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'MonthlyPayment'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [128] 

ON [1].IssueYearMonth = [128].IssueYearMonth AND 
 
[1].EmployeeRef = [128].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value129, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'Tax'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [129] 

ON [1].IssueYearMonth = [129].IssueYearMonth AND 
 
[1].EmployeeRef = [129].EmployeeRef 

LEFT OUTER JOIN


(SELECT C.Title, SUM(PCI.Value) AS value130, PC.IssueYearMonth, PC.EmployeeRef
 
FROM  HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID 

AND C.Name = 'Payable'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [130] 

ON [1].IssueYearMonth = [130].IssueYearMonth AND 
 
[1].EmployeeRef = [130].EmployeeRef 

LEFT OUTER JOIN

(SELECT     C.Title, SUM(PCI.Value) AS value51, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'bonramezan'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [51] ON [1].IssueYearMonth = [51].IssueYearMonth AND 
 
[1].EmployeeRef = [51].EmployeeRef LEFT OUTER JOIN
 
(SELECT     C.Title, SUM(PCI.Value) AS value52, PC.IssueYearMonth, PC.EmployeeRef
 
FROM          HCM3.PayCalc AS PC INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'UF157'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [52] ON [1].IssueYearMonth = [52].IssueYearMonth AND 
 
[1].EmployeeRef = [52].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value70, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'MonthlyTax'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [70] 
ON 
[1].IssueYearMonth = [70].IssueYearMonth 
AND 
[1].EmployeeRef = [70].EmployeeRef 
LEFT OUTER JOIN
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value71, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
 
HCM3.PayCalcItem AS PCI ON PC.PayCalcID = PCI.PayCalcRef INNER JOIN
 
HCM3.CompensationFactor AS C ON PCI.CompensationFactorRef = C.CompensationFactorID AND C.Name = 'Otherbenefit'
 
GROUP BY C.Title, PC.IssueYearMonth, PC.EmployeeRef) AS [71] ON [1].IssueYearMonth = [71].IssueYearMonth AND 
 
[1].EmployeeRef = [71].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value72, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'KhesaratKarkona'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [72] 
ON 
[1].IssueYearMonth = [72].IssueYearMonth 
AND 
[1].EmployeeRef = [72].EmployeeRef 
LEFT OUTER JOIN
(
SELECT B.Title,SUM(A.Value) AS value53, A.ApplyYearMonth,  AA.EmployeeRef 

FROM HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID 

AND B.Name = 'AbsenceInMonth'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [53] 

ON [1].IssueYearMonth = [53].ApplyYearMonth AND 
 

[1].EmployeeRef = [53].EmployeeRef LEFT OUTER JOIN
(
SELECT     
B.Title, 
SUM(A.Value) AS value111, 
A.ApplyYearMonth, 
AA.EmployeeRef
FROM          
HCM3.AttendanceCalc AS AA 
INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'MainWork'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [111] ON [1].IssueYearMonth = [111].ApplyYearMonth 
AND 
 
[1].EmployeeRef = [111].EmployeeRef LEFT OUTER JOIN

(
SELECT     
C.Title, 
SUM(PCI.Value) AS value112, 
PC.IssueYearMonth,
PC.EmployeeRef
FROM          
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'SumKarkdeSal'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [112] 
ON 
[1].IssueYearMonth = [112].IssueYearMonth 
AND 
[1].EmployeeRef = [112].EmployeeRef 
LEFT OUTER JOIN 
 
(SELECT     B.Title, SUM(A.Value) AS value54, A.ApplyYearMonth, AA.EmployeeRef
 
FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID 
AND B.Name = 'OverWorkPaTime'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [54] ON [1].IssueYearMonth = [54].ApplyYearMonth AND 
 
[1].EmployeeRef = [54].EmployeeRef LEFT OUTER JOIN
 
(SELECT     B.Title, SUM(A.Value) AS value55, A.ApplyYearMonth, AA.EmployeeRef
 
FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'HolidayPayTime'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [55] ON [1].IssueYearMonth = [55].ApplyYearMonth AND 
 
[1].EmployeeRef = [55].EmployeeRef LEFT OUTER JOIN
 
(SELECT     B.Title, SUM(A.Value) AS value56, A.ApplyYearMonth, AA.EmployeeRef
 
FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'NightPayTime'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [56] ON [1].IssueYearMonth = [56].ApplyYearMonth AND 

[1].EmployeeRef = [56].EmployeeRef LEFT OUTER JOIN
 
(SELECT     B.Title, SUM(A.Value) AS value57, A.ApplyYearMonth, AA.EmployeeRef
 
FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'wrkshab'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [57] ON [1].IssueYearMonth = [57].ApplyYearMonth AND 
 
[1].EmployeeRef = [57].EmployeeRef LEFT OUTER JOIN
 
(SELECT     B.Title, SUM(A.Value) AS value58, A.ApplyYearMonth, AA.EmployeeRef
 
FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF39'
 
GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [58] ON [1].IssueYearMonth = [58].ApplyYearMonth AND 
 
[1].EmployeeRef = [58].EmployeeRef LEFT OUTER JOIN
 
--    (SELECT     B.Title, SUM(A.Value) AS value59, A.ApplyYearMonth, AA.EmployeeRef
 
--      FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--                             HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--                             HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF335'
 
--      GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [59] ON [1].IssueYearMonth = [59].ApplyYearMonth AND 
 
--[1].EmployeeRef = [59].EmployeeRef LEFT OUTER JOIN
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value59, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'UF335'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [59] 
ON 
[1].IssueYearMonth = [59].IssueYearMonth 
AND 
[1].EmployeeRef = [59].EmployeeRef 
LEFT OUTER JOIN 


 
--(SELECT     B.Title, SUM(A.Value) AS value60, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'moavaghe'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [60] ON [1].IssueYearMonth = [60].ApplyYearMonth AND 
 
--[1].EmployeeRef = [60].EmployeeRef LEFT OUTER JOIN
 
 (
SELECT     
C.Title, 
SUM(PCI.Value) AS value60, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'moavaghe'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [60] 
ON 
[1].IssueYearMonth = [60].IssueYearMonth 
AND 
[1].EmployeeRef = [60].EmployeeRef 
LEFT OUTER JOIN 


--    (SELECT     B.Title, SUM(A.Value) AS value61, A.ApplyYearMonth, AA.EmployeeRef
 
--      FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--                             HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--                             HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF357'
 
--      GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [61] ON [1].IssueYearMonth = [61].ApplyYearMonth AND 
 
--[1].EmployeeRef = [61].EmployeeRef LEFT OUTER JOIN
 
--(SELECT     B.Title, SUM(A.Value) AS value62, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'HAGHESUKHT'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [62] ON [1].IssueYearMonth = [62].ApplyYearMonth AND 
 
--[1].EmployeeRef = [62].EmployeeRef LEFT OUTER JOIN
 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value62, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'HAGHESUKHT'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [62] 
ON 
[1].IssueYearMonth = [62].IssueYearMonth 
AND 
[1].EmployeeRef = [62].EmployeeRef 
LEFT OUTER JOIN 


--(SELECT     B.Title, SUM(A.Value) AS value63, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF44'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [63] ON [1].IssueYearMonth = [63].ApplyYearMonth AND 
 
--[1].EmployeeRef = [63].EmployeeRef LEFT OUTER JOIN


(
SELECT     
C.Title, 
SUM(PCI.Value) AS value63, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF362'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [63] 
ON 
[1].IssueYearMonth = [63].IssueYearMonth 
AND 
[1].EmployeeRef = [63].EmployeeRef 
LEFT OUTER JOIN 

 
--(SELECT     B.Title, SUM(A.Value) AS value64, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF369'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [64] ON [1].IssueYearMonth = [64].ApplyYearMonth AND 
 
--[1].EmployeeRef = [64].EmployeeRef 
--LEFT OUTER JOIN 

(
SELECT     
C.Title, 
SUM(PCI.Value) AS value64, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF369'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [64] 
ON 
[1].IssueYearMonth = [64].IssueYearMonth 
AND 
[1].EmployeeRef = [64].EmployeeRef 
LEFT OUTER JOIN 


--(SELECT     B.Title, SUM(A.Value) AS value77, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF330'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [77] ON [1].IssueYearMonth = [77].ApplyYearMonth AND 
 
--[1].EmployeeRef = [77].EmployeeRef 
--LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value77, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF330'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [77] 
ON 
[1].IssueYearMonth = [77].IssueYearMonth 
AND 
[1].EmployeeRef = [77].EmployeeRef 
LEFT OUTER JOIN 

(
SELECT     
C.Title, 
SUM(PCI.Value) AS value78, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF329'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [78] 
ON 
[1].IssueYearMonth = [78].IssueYearMonth 
AND 
[1].EmployeeRef = [78].EmployeeRef 
LEFT OUTER JOIN 


(
SELECT     
C.Title, 
SUM(PCI.Value) AS value65, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF300'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [65] 
ON 
[1].IssueYearMonth = [65].IssueYearMonth 
AND 
[1].EmployeeRef = [65].EmployeeRef 
LEFT OUTER JOIN 
--(
--SELECT     
--B.Title, SUM(A.Value) AS value66, A.ApplyYearMonth, AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'UF358'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [66] ON [1].IssueYearMonth = [66].ApplyYearMonth AND 
 
--[1].EmployeeRef = [66].EmployeeRef 
--LEFT OUTER JOIN 


(
SELECT     
C.Title, 
SUM(PCI.Value) AS value66, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'UF358'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
	
) AS [66] 
ON 
[1].IssueYearMonth = [66].IssueYearMonth 
AND
[1].EmployeeRef = [66].EmployeeRef 
LEFT OUTER JOIN


(
SELECT     
C.Title, 
SUM(PCI.Value) AS value67, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'tavonimasrafkarkonan'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
	
) AS [67] 
ON 
[1].IssueYearMonth = [67].IssueYearMonth 
AND
[1].EmployeeRef = [67].EmployeeRef 
LEFT OUTER JOIN
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value68, 
PC.IssueYearMonth, 
PC.EmployeeRef
FROM 
HCM3.PayCalc AS PC 
INNER JOIN
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID
AND
C.Name = 'OtherDeduction'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [68] 
ON 
[1].IssueYearMonth = [68].IssueYearMonth 
AND
[1].EmployeeRef = [68].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value61, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'UF357'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [61] 
ON 
[1].IssueYearMonth = [61].IssueYearMonth 
AND 
[1].EmployeeRef = [61].EmployeeRef 
LEFT OUTER JOIN 
(
SELECT     
C.Title, 
SUM(PCI.Value) AS value113, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'UF373'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [113] 
ON 
[1].IssueYearMonth = [113].IssueYearMonth 
AND 
[1].EmployeeRef = [113].EmployeeRef 
LEFT OUTER JOIN 

(
SELECT     
C.Title, 
SUM(PCI.Value) AS value69, 
PC.IssueYearMonth, 
PC.EmployeeRef 
FROM          
HCM3.PayCalc AS PC 
INNER JOIN 
HCM3.PayCalcItem AS PCI 
ON 
PC.PayCalcID = PCI.PayCalcRef 
INNER JOIN 
HCM3.CompensationFactor AS C 
ON 
PCI.CompensationFactorRef = C.CompensationFactorID 
AND 
C.Name = 'SARPARASTI'
GROUP BY 
C.Title, 
PC.IssueYearMonth, 
PC.EmployeeRef
) AS [69] 
ON 
[1].IssueYearMonth = [69].IssueYearMonth 
AND 
[1].EmployeeRef = [69].EmployeeRef 
LEFT OUTER JOIN 

--(
--SELECT     
--B.Title, 
--SUM(A.Value) AS value69, 
--A.ApplyYearMonth, 
--AA.EmployeeRef
 
--FROM          HCM3.AttendanceCalc AS AA INNER JOIN
 
--HCM3.AttendanceCalcMonthlyItem AS A ON AA.AttendanceCalcID = A.AttendanceCalcRef INNER JOIN
 
--HCM3.AttendanceFactor AS B ON A.AttendanceFactorRef = B.AttendanceFactorID AND B.Name = 'SARPARASTI'
 
--GROUP BY B.Title, A.ApplyYearMonth, AA.EmployeeRef) AS [69] ON [1].IssueYearMonth = [69].ApplyYearMonth AND 
 
--[1].EmployeeRef = [69].EmployeeRef LEFT OUTER JOIN
 
HCM3.EmployeeBranchInfo AS [37] ON EMP.EmployeeID = [37].EmployeeRef LEFT OUTER JOIN
 
GNR3.Branch AS [38] ON [37].BranchRef = [38].BranchID LEFT OUTER JOIN
 
HCM3.EmployeePaymentLocation AS EPL ON EMP.EmployeeID = EPL.EmployeeRef
 
WHERE     ([33].TypeCode = 2) AND ([31].ExpiryYearMonth IS NULL) 
--and 
--EPL.AccountNumber ='700831962991' and [30].NationalID ='1050214706'
--and
--	SUBSTRING(CAST([1].IssueYearMonth AS nvarchar), 1, 4)='1399' 
--	and
--SUBSTRING(CAST([1].IssueYearMonth AS nvarchar), 5, 2) ='02'
GROUP BY EMP.Code, [30].FirstName, [30].LastName,[30].FatherName ,[30].NationalID , [30].IDNumber,[30].BirthDate, [38].Title,
[1].IssueYearMonth, [31].Code, EPL.AccountNumber,[1].value1,  
[54].value54,  [55].value55, [26].value26, [41].value41, [57].value57, [39].value39, 
[50].value50, [12].value12, [25].value25, [73].value73, [2].value2, [6].value6, [19].value19,
[4].value4, [8].value8, [5].value5,  [3].value3, [7].value7, [14].value14,[11].value11, 
[9].value9, [15].value15, [45].value45,[42].value42, [62].value62,[35].value35, 
[43].value43,[69].value69, [47].value47,[63].value63, [64].value64,[49].value49  ,
[60].value60  ,[22].value22  ,[36].value36   ,[10].value10  ,[40].value40   ,[20].value20  ,
[51].value51  ,[61].value61  ,[66].value66   ,[59].value59   ,[46].value46  , [16].value16     ,
[17].value17    ,[68].value68  , [72].value72  ,[48].value48  ,[21].value21 ,[65].value65   ,
[18].value18   ,[67].value67   ,[70].value70  , [13].value13  ,[23].value23  ,[24].value24  , 
EPL.AccountNumber  , [30].FirstName ,[30].LastName  ,EMP.Code  ,[30].FatherName  ,
[30].NationalID  , [30].IDNumber  ,[30].BirthDate  ,[38].Title  ,[1].IssueYearMonth , 
[1].IssueYearMonth ,[77].value77,[1].value1, [12].value12,[111].value111,[78].value78,
[112].value112,[114].value114,[115].value115,[113].value113,[116].value116,[117].value117,
[118].value118,[119].value119,[120].value120,[121].value121,[122].value122,[123].value123,
[124].value124,[125].value125,[126].value126,[127].value127,[128].value128,[129].value129,
[130].value130,[53].value53
GO


