using Kosha.DataLayer.Helper;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kosha.DataLayer.Context
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }

        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<AuthenticationCode> AuthenticationCode { get; set; }
        public virtual DbSet<KoshaContract> KoshaContract { get; set; }
        public virtual DbSet<KoshaDsw> KoshaDsw { get; set; }
        public virtual DbSet<KoshaLoginInfo> KoshaLoginInfo { get; set; }
        public virtual DbSet<KoshaPayRoll> KoshaPayRoll { get; set; }
        public virtual DbSet<KoshaSource01> KoshaSource01 { get; set; }
        public virtual DbSet<KoshaSource02> KoshaSource02 { get; set; }
        public virtual DbSet<KoshaTax> KoshaTax { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<PortalSetting> PortalSetting { get; set; }

        public virtual DbSet<Kosha_Summary> KoshaSummary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ContextManager.connectionStrings["Sg3ConnectionString"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthenticationCode>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasQueryFilter(p => !p.IsDeleted);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasQueryFilter(p => !p.IsDeleted);
            });


            modelBuilder.Entity<KoshaContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_Contract");

                entity.Property(e => e.بنکارگری).HasColumnName("بن کارگری");

                entity.Property(e => e.تاریختولد).HasColumnName("تاریخ تولد");

                entity.Property(e => e.تعداداولاد).HasColumnName("تعداد اولاد");

                entity.Property(e => e.جمعمزدمبناروزانه).HasColumnName("جمع مزد مبنا روزانه");

                entity.Property(e => e.جمعمزدمبناماهانه).HasColumnName("جمع مزد مبنا ماهانه");

                entity.Property(e => e.جمعکلمزایا).HasColumnName("جمع کل مزایا");

                entity.Property(e => e.جمعکلمزدومزایا).HasColumnName("جمع کل مزد و مزایا");

                entity.Property(e => e.جنسیت)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.حقاولاد).HasColumnName("حق اولاد");

                entity.Property(e => e.حقمسکن).HasColumnName("حق مسکن");

                entity.Property(e => e.شمارهشناسنامه).HasColumnName("شماره شناسنامه");

                entity.Property(e => e.عنوانشغل).HasColumnName("عنوان شغل");

                entity.Property(e => e.محلتولد).HasColumnName("محل تولد");

                entity.Property(e => e.مدرکتحصیلی).HasColumnName("مدرک تحصیلی");

                entity.Property(e => e.مزدروزانه).HasColumnName("مزد روزانه");

                entity.Property(e => e.مزدماهانه).HasColumnName("مزد ماهانه");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.نامپدر).HasColumnName("نام پدر");

                entity.Property(e => e.نامپروژه).HasColumnName("نام پروژه");

                entity.Property(e => e.وضعیتتاهل)
                    .IsRequired()
                    .HasColumnName("وضعیت تاهل")
                    .HasMaxLength(5);

                entity.Property(e => e.وضعیتسربازی)
                    .IsRequired()
                    .HasColumnName("وضعیت سربازی")
                    .HasMaxLength(13);

                entity.Property(e => e.پایهسنواتروزانه).HasColumnName("پایه سنوات روزانه");

                entity.Property(e => e.پایهسنواتماهانه).HasColumnName("پایه سنوات ماهانه");

                entity.Property(e => e.کدشغل).HasColumnName("کد شغل");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی");

                entity.Property(e => e.کدپرسنلی).HasColumnName("کد پرسنلی");

                entity.Property(e => e.کدپستی).HasColumnName("کد پستی");
            });

            modelBuilder.Entity<KoshaDsw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_DSW");

                entity.Property(e => e.DswBdate).HasColumnName("DSW_BDATE");

                entity.Property(e => e.DswBime).HasColumnName("DSW_BIME");

                entity.Property(e => e.DswDd).HasColumnName("DSW_DD");

                entity.Property(e => e.DswDname).HasColumnName("DSW_DNAME");

                entity.Property(e => e.DswEdate).HasColumnName("DSW_EDATE");

                entity.Property(e => e.DswFname).HasColumnName("DSW_FNAME");

                entity.Property(e => e.DswId)
                    .IsRequired()
                    .HasColumnName("DSW_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DswId1).HasColumnName("DSW_ID1");

                entity.Property(e => e.DswIdate).HasColumnName("DSW_IDATE");

                entity.Property(e => e.DswIdno).HasColumnName("DSW_IDNO");

                entity.Property(e => e.DswIdplc).HasColumnName("DSW_IDPLC");

                entity.Property(e => e.DswJob).HasColumnName("DSW_JOB");

                entity.Property(e => e.DswListno)
                    .IsRequired()
                    .HasColumnName("DSW_LISTNO")
                    .HasMaxLength(2);

                entity.Property(e => e.DswLname).HasColumnName("DSW_LNAME");

                entity.Property(e => e.DswMah).HasColumnName("DSW_MAH");

                entity.Property(e => e.DswMash).HasColumnName("DSW_MASH");

                entity.Property(e => e.DswMaz).HasColumnName("DSW_MAZ");

                entity.Property(e => e.DswMm).HasColumnName("DSW_MM");

                entity.Property(e => e.DswNat).HasColumnName("DSW_NAT");

                entity.Property(e => e.DswOcp).HasColumnName("DSW_OCP");

                entity.Property(e => e.DswPrate)
                    .IsRequired()
                    .HasColumnName("DSW_PRATE")
                    .HasMaxLength(1);

                entity.Property(e => e.DswRooz).HasColumnName("DSW_ROOZ");

                entity.Property(e => e.DswSdate).HasColumnName("DSW_SDATE");

                entity.Property(e => e.DswSex).HasColumnName("DSW_SEX");

                entity.Property(e => e.DswTotl).HasColumnName("DSW_TOTL");

                entity.Property(e => e.DswYy).HasColumnName("DSW_YY");

                entity.Property(e => e.PerNatcod).HasColumnName("PER_NATCOD");
            });

            modelBuilder.Entity<KoshaLoginInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_LoginInfo");

                entity.Property(e => e.شمارهحساب).HasColumnName("شماره حساب");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی");
            });

            modelBuilder.Entity<KoshaPayRoll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_PayRoll");

                entity.Property(e => e.اضافهکاری).HasColumnName("اضافه کاری");

                entity.Property(e => e.اضافهکاریثابت).HasColumnName("اضافه کاری ثابت");

                entity.Property(e => e.ایابوذهاب).HasColumnName("ایاب و ذهاب");

                entity.Property(e => e.بیمهتامیناجتماعی).HasColumnName("بیمه تامین اجتماعی");

                entity.Property(e => e.تاریختولد).HasColumnName("تاریخ تولد");

                entity.Property(e => e.تعداداولاد).HasColumnName("تعداد اولاد");

                entity.Property(e => e.تعطیلکاری).HasColumnName("تعطیل کاری");

                entity.Property(e => e.جمعاقساطوام).HasColumnName("جمع اقساط وام");

                entity.Property(e => e.جمعكسور).HasColumnName("جمع كسور");

                entity.Property(e => e.جمعمزایا).HasColumnName("جمع مزایا");

                entity.Property(e => e.حقاولاد).HasColumnName("حق اولاد");

                entity.Property(e => e.حقبن).HasColumnName("حق بن");

                entity.Property(e => e.حقخواربار).HasColumnName("حق خواربار");

                entity.Property(e => e.حقشیر).HasColumnName("حق شیر");

                entity.Property(e => e.حقمسکن).HasColumnName("حق مسکن");

                entity.Property(e => e.حقناهار).HasColumnName("حق ناهار");

                entity.Property(e => e.حقوقپایه).HasColumnName("حقوق پایه");

                entity.Property(e => e.خالصپرداختی).HasColumnName("خالص پرداختی");

                entity.Property(e => e.رندحقوق).HasColumnName("رند حقوق");

                entity.Property(e => e.شمارهحساب).HasColumnName("شماره حساب");

                entity.Property(e => e.شمارهشناسنامه).HasColumnName("شماره شناسنامه");

                entity.Property(e => e.كاركردحقغذا).HasColumnName("كاركرد حق غذا");

                entity.Property(e => e.ماندهمرخصی).HasColumnName("مانده مرخصی");

                entity.Property(e => e.مرکزهزینه).HasColumnName("مرکز هزینه");

                entity.Property(e => e.معوقهایابوذهاب).HasColumnName("معوقه ایاب و ذهاب");

                entity.Property(e => e.میزانمرخصیدرماه).HasColumnName("میزان مرخصی در ماه");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.نامپدر).HasColumnName("نام پدر");

                entity.Property(e => e.نوبتکاری).HasColumnName("نوبت کاری");

                entity.Property(e => e.هزینهرفاهی).HasColumnName("هزینه رفاهی");

                entity.Property(e => e.وامسامان).HasColumnName("وام سامان");

                entity.Property(e => e.وامموسسه).HasColumnName("وام موسسه");

                entity.Property(e => e.پایهسنوات).HasColumnName("پایه سنوات");

                entity.Property(e => e.کارکرداضافهکاری).HasColumnName("کارکرد اضافه کاری");

                entity.Property(e => e.کارکردتعطیلکاری).HasColumnName("کارکرد تعطیل کاری");

                entity.Property(e => e.کارکردشبکاری).HasColumnName("کارکرد شبکاری");

                entity.Property(e => e.کارکردماموریت).HasColumnName("کارکرد ماموریت");

                entity.Property(e => e.کارکردمعوقه).HasColumnName("کارکرد معوقه");

                entity.Property(e => e.کارکردموثر).HasColumnName("کارکرد موثر");

                entity.Property(e => e.کارکردنوبتکاری)
                    .HasColumnName("کارکرد نوبت کاری")
                    .HasColumnType("numeric(22, 2)");

                entity.Property(e => e.کارکردپاداش).HasColumnName("کارکرد پاداش");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی");

                entity.Property(e => e.کدپرسنلی).HasColumnName("کد پرسنلی");

                entity.Property(e => e.کسربیمهتکمیلی).HasColumnName("کسر بیمه تکمیلی");

                entity.Property(e => e.کسربیمهتکمیلیافرادتحتتکفل).HasColumnName("کسر بیمه تکمیلی افراد تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیافرادغیرتحتتکفل).HasColumnName("کسر بیمه تکمیلی افرادغیر تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیسرپرست).HasColumnName("کسر بیمه تکمیلی سرپرست");

                entity.Property(e => e.کسربیمهتکمیلیماهمعوقه).HasColumnName("کسر بیمه تکمیلی ماه معوقه");

                entity.Property(e => e.کمکهزینهرفاهی).HasColumnName("کمک هزینه رفاهی");
            });

            modelBuilder.Entity<KoshaSource01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_Source01");

                entity.Property(e => e.Tt).HasColumnName("TT");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e._1حقناهار).HasColumnName("1حق ناهار");

                entity.Property(e => e.ارزشافزودهبیمهتکمیلی).HasColumnName("ارزش افزوده بیمه تکمیلی");

                entity.Property(e => e.اضافهکاری).HasColumnName("اضافه کاری");

                entity.Property(e => e.اضافهکاریثابت).HasColumnName("اضافه کاری ثابت");

                entity.Property(e => e.ایابوذهاب).HasColumnName("ایاب و ذهاب");

                entity.Property(e => e.بنکارگری).HasColumnName("بن کارگری");

                entity.Property(e => e.بیمه23).HasColumnName("بیمه 23%");

                entity.Property(e => e.بیمهتامیناجتماعی).HasColumnName("بیمه تامین اجتماعی");

                entity.Property(e => e.بیمهتکمیلی).HasColumnName("بیمه تکمیلی");

                entity.Property(e => e.تاریخترککار).HasColumnName("تاریخ ترک کار");

                entity.Property(e => e.تاریختولد).HasColumnName("تاریخ تولد");

                entity.Property(e => e.تاریخشروعکار).HasColumnName("تاریخ شروع کار");

                entity.Property(e => e.تعداداولاد).HasColumnName("تعداد اولاد");

                entity.Property(e => e.تعطیلکاری).HasColumnName("تعطیل کاری");

                entity.Property(e => e.جمعاقساطوام).HasColumnName("جمع اقساط وام");

                entity.Property(e => e.جمعباارزشافزوده).HasColumnName("جمع با ارزش افزوده");

                entity.Property(e => e.جمعبابیمه).HasColumnName("جمع با بیمه");

                entity.Property(e => e.جمعكسور).HasColumnName("جمع كسور");

                entity.Property(e => e.جمعمزایا).HasColumnName("جمع مزایا");

                entity.Property(e => e.جمعکل).HasColumnName("جمع کل");

                entity.Property(e => e.جمعکلحقبیمهاعمازحقبیمهوبیمهبیکاری).HasColumnName("جمع کل حق بیمه اعم از حق بیمه و بیمه بیکاری");

                entity.Property(e => e.حسنانجام10).HasColumnName("حسن انجام 10%");

                entity.Property(e => e.حقاولاد).HasColumnName("حق اولاد");

                entity.Property(e => e.حقبن).HasColumnName("حق بن");

                entity.Property(e => e.حقبیمهبیکاری).HasColumnName("حق بیمه بیکاری");

                entity.Property(e => e.حقبیمهسهمکارفرما).HasColumnName("حق بیمه سهم کارفرما");

                entity.Property(e => e.حقخواربار).HasColumnName("حق خواربار");

                entity.Property(e => e.حقشیر).HasColumnName("حق شیر");

                entity.Property(e => e.حقمسکن).HasColumnName("حق مسکن");

                entity.Property(e => e.حقوقپایه).HasColumnName("حقوق پایه");

                entity.Property(e => e.خالصپرداختی).HasColumnName("خالص پرداختی");

                entity.Property(e => e.خالصپرداختیبدونعیدیوسنواتومرخصی).HasColumnName("خالص پرداختی بدون عیدی و سنوات و مرخصی");

                entity.Property(e => e.دستمزدومزایایمشمولماهانه).HasColumnName("دستمزد و مزایای مشمول ماهانه");

                entity.Property(e => e.رندحقوق).HasColumnName("رند حقوق");

                entity.Property(e => e.سال).HasColumnName("سال ");

                entity.Property(e => e.سایرکسور).HasColumnName("سایر کسور");

                entity.Property(e => e.سنواتصورتحساب).HasColumnName("سنوات صورتحساب");

                entity.Property(e => e.سپرده5).HasColumnName("سپرده 5%");

                entity.Property(e => e.شمارهبیمه).HasColumnName("شماره بیمه");

                entity.Property(e => e.شمارهحساب).HasColumnName("شماره حساب");

                entity.Property(e => e.شمارهشناسنامه).HasColumnName("شماره شناسنامه");

                entity.Property(e => e.عمروحوادث).HasColumnName("عمر و حوادث");

                entity.Property(e => e.عیدیوپاداش).HasColumnName("عیدی و پاداش");

                entity.Property(e => e.غیرمستمرمشمول).HasColumnName("غیر مستمر - مشمول");

                entity.Property(e => e.غیرمستمرمشمولوغیرمشمول).HasColumnName("غیر مستمر - مشمول و غیر مشمول");

                entity.Property(e => e.كاركردحقغذا).HasColumnName("كاركرد حق غذا");

                entity.Property(e => e.كلحقوقومزايا).HasColumnName("كل حقوق و مزايا");

                entity.Property(e => e.ماخذبیمه).HasColumnName("ماخذ بیمه");

                entity.Property(e => e.مالیاتبرارزشافزوده).HasColumnName("مالیات بر ارزش افزوده");

                entity.Property(e => e.ماندهمرخصی).HasColumnName("مانده مرخصی");

                entity.Property(e => e.مجموععیدیوسنواتومرخصی).HasColumnName("مجموع عیدی و سنوات و مرخصی");

                entity.Property(e => e.محلتولد).HasColumnName("محل تولد");

                entity.Property(e => e.مزایایمشمول).HasColumnName("مزایای مشمول");

                entity.Property(e => e.مزدروزانه).HasColumnName("مزد روزانه");

                entity.Property(e => e.مزدماهانه).HasColumnName("مزد ماهانه");

                entity.Property(e => e.مستمرحقوقپایهبنومسکنوحقاولاد).HasColumnName("مستمر - حقوق پایه بن و مسکن و حق اولاد");

                entity.Property(e => e.مستمرحقوقپایهوپایهسنوات).HasColumnName("مستمر - حقوق پایه و پایه سنوات");

                entity.Property(e => e.مشمولبیمه).HasColumnName("مشمول بیمه");

                entity.Property(e => e.مشمولوغیرمشمول).HasColumnName("مشمول و غیر مشمول");

                entity.Property(e => e.معوقهایابوذهاب).HasColumnName("معوقه ایاب و ذهاب");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.نامشعبه).HasColumnName("نام شعبه");

                entity.Property(e => e.نامپدر).HasColumnName("نام پدر");

                entity.Property(e => e.نوبتکاری).HasColumnName("نوبت کاری");

                entity.Property(e => e.هزینهرفاهی).HasColumnName("هزینه رفاهی");

                entity.Property(e => e.وامسامان).HasColumnName("وام سامان");

                entity.Property(e => e.وامموسسه).HasColumnName("وام موسسه");

                entity.Property(e => e.پایهسنوات).HasColumnName("پایه سنوات");

                entity.Property(e => e.کارکرداضافهکاری).HasColumnName("کارکرد اضافه کاری");

                entity.Property(e => e.کارکرداضافهکاری1).HasColumnName("کارکرد_اضافه کاری");

                entity.Property(e => e.کارکردتعطیلکاری).HasColumnName("کارکرد تعطیل کاری");

                entity.Property(e => e.کارکردشبکاری).HasColumnName("کارکرد شبکاری");

                entity.Property(e => e.کارکردماموریت).HasColumnName("کارکرد ماموریت");

                entity.Property(e => e.کارکردمعوقه).HasColumnName("کارکرد معوقه");

                entity.Property(e => e.کارکردموثر).HasColumnName("کارکرد موثر");

                entity.Property(e => e.کارکردنوبتکاری).HasColumnName("کارکرد نوبت کاری");

                entity.Property(e => e.کارکردپاداش).HasColumnName("کارکرد پاداش");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی ");

                entity.Property(e => e.کدپرسنلی).HasColumnName("کد پرسنلی");

                entity.Property(e => e.کسربیمهتکمیلی).HasColumnName("کسر بیمه تکمیلی");

                entity.Property(e => e.کسربیمهتکمیلیافرادتحتتکفل).HasColumnName("کسر بیمه تکمیلی افراد تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیافرادغیرتحتتکفل).HasColumnName("کسر بیمه تکمیلی افرادغیر تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیسرپرست).HasColumnName("کسر بیمه تکمیلی سرپرست");

                entity.Property(e => e.کسربیمهتکمیلیماهمعوقه).HasColumnName("کسر بیمه تکمیلی ماه معوقه");

                entity.Property(e => e.کمکهزینهرفاهی).HasColumnName("کمک هزینه رفاهی");
            });

            modelBuilder.Entity<Kosha_Summary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_Summary");

                entity.Property(e => e._1حق_ناهار).HasColumnName("1حق_ناهار");

                entity.Property(e => e.بیمه_23_).HasColumnName("بیمه_23%");

                entity.Property(e => e.حسن_انجام_10_).HasColumnName("حسن_انجام_10%");

                entity.Property(e => e.حق_بن).HasColumnName("حق بن");

                entity.Property(e => e.سپرده_5_).HasColumnName("سپرده_5%");
            });

            modelBuilder.Entity<KoshaSource02>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_Source02");

                entity.Property(e => e._1حقناهار).HasColumnName("1حق ناهار");

                entity.Property(e => e.اضافهکاری).HasColumnName("اضافه کاری");

                entity.Property(e => e.اضافهکاریثابت).HasColumnName("اضافه کاری ثابت");

                entity.Property(e => e.ایابوذهاب).HasColumnName("ایاب و ذهاب");

                entity.Property(e => e.بنکارگری).HasColumnName("بن کارگری");

                entity.Property(e => e.بیمهتامیناجتماعی).HasColumnName("بیمه تامین اجتماعی");

                entity.Property(e => e.تاریخترککار).HasColumnName("تاریخ ترک کار");

                entity.Property(e => e.تاریختولد).HasColumnName("تاریخ تولد");

                entity.Property(e => e.تاریخشروعکار).HasColumnName("تاریخ شروع کار");

                entity.Property(e => e.تعداداولاد).HasColumnName("تعداد اولاد");

                entity.Property(e => e.تعطیلکاری).HasColumnName("تعطیل کاری");

                entity.Property(e => e.جمعاقساطوام).HasColumnName("جمع اقساط وام");

                entity.Property(e => e.جمعكسور).HasColumnName("جمع كسور");

                entity.Property(e => e.جمعمزایا).HasColumnName("جمع مزایا");

                entity.Property(e => e.جمعکلحقبیمهاعمازحقبیمهوبیمهبیکاری).HasColumnName("جمع کل حق بیمه اعم از حق بیمه و بیمه بیکاری");

                entity.Property(e => e.حقاولاد).HasColumnName("حق اولاد");

                entity.Property(e => e.حقبن).HasColumnName("حق بن");

                entity.Property(e => e.حقبیمهبیکاری).HasColumnName("حق بیمه بیکاری");

                entity.Property(e => e.حقبیمهسهمکارفرما).HasColumnName("حق بیمه سهم کارفرما");

                entity.Property(e => e.حقخواربار).HasColumnName("حق خواربار");

                entity.Property(e => e.حقشیر).HasColumnName("حق شیر");

                entity.Property(e => e.حقمسکن).HasColumnName("حق مسکن");

                entity.Property(e => e.حقوقپایه).HasColumnName("حقوق پایه");

                entity.Property(e => e.خالصپرداختی).HasColumnName("خالص پرداختی");

                entity.Property(e => e.دستمزدومزایایمشمولماهانه).HasColumnName("دستمزد و مزایای مشمول ماهانه");

                entity.Property(e => e.رندحقوق).HasColumnName("رند حقوق");

                entity.Property(e => e.سال).HasColumnName("سال ");

                entity.Property(e => e.سایرکسور).HasColumnName("سایر کسور");

                entity.Property(e => e.شمارهبیمه).HasColumnName("شماره بیمه");

                entity.Property(e => e.شمارهحساب).HasColumnName("شماره حساب");

                entity.Property(e => e.شمارهشناسنامه).HasColumnName("شماره شناسنامه");

                entity.Property(e => e.كاركردحقغذا).HasColumnName("كاركرد حق غذا");

                entity.Property(e => e.كلحقوقومزايا).HasColumnName("كل حقوق و مزايا");

                entity.Property(e => e.ماخذبیمه).HasColumnName("ماخذ بیمه");

                entity.Property(e => e.ماندهمرخصی).HasColumnName("مانده مرخصی");

                entity.Property(e => e.محلتولد).HasColumnName("محل تولد");

                entity.Property(e => e.مزایایمشمول).HasColumnName("مزایای مشمول");

                entity.Property(e => e.مزدروزانه).HasColumnName("مزد روزانه");

                entity.Property(e => e.مزدماهانه).HasColumnName("مزد ماهانه");

                entity.Property(e => e.مشمولوغیرمشمول).HasColumnName("مشمول و غیر مشمول");

                entity.Property(e => e.معوقهایابوذهاب).HasColumnName("معوقه ایاب و ذهاب");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.نامشعبه).HasColumnName("نام شعبه");

                entity.Property(e => e.نامپدر).HasColumnName("نام پدر");

                entity.Property(e => e.نوبتکاری).HasColumnName("نوبت کاری");

                entity.Property(e => e.هزینهرفاهی).HasColumnName("هزینه رفاهی");

                entity.Property(e => e.وامسامان).HasColumnName("وام سامان");

                entity.Property(e => e.وامموسسه).HasColumnName("وام موسسه");

                entity.Property(e => e.پایهسنوات).HasColumnName("پایه سنوات");

                entity.Property(e => e.کارکرداضافهکاری).HasColumnName("کارکرد اضافه کاری");

                entity.Property(e => e.کارکرداضافهکاری1).HasColumnName("کارکرد_اضافه کاری");

                entity.Property(e => e.کارکردتعطیلکاری).HasColumnName("کارکرد تعطیل کاری");

                entity.Property(e => e.کارکردشبکاری).HasColumnName("کارکرد شبکاری");

                entity.Property(e => e.کارکردماموریت).HasColumnName("کارکرد ماموریت");

                entity.Property(e => e.کارکردمعوقه).HasColumnName("کارکرد معوقه");

                entity.Property(e => e.کارکردموثر).HasColumnName("کارکرد موثر");

                entity.Property(e => e.کارکردنوبتکاری).HasColumnName("کارکرد نوبت کاری");

                entity.Property(e => e.کارکردپاداش).HasColumnName("کارکرد پاداش");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی ");

                entity.Property(e => e.کدپرسنلی).HasColumnName("کد پرسنلی");

                entity.Property(e => e.کسربیمهتکمیلی).HasColumnName("کسر بیمه تکمیلی");

                entity.Property(e => e.کسربیمهتکمیلیافرادتحتتکفل).HasColumnName("کسر بیمه تکمیلی افراد تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیافرادغیرتحتتکفل).HasColumnName("کسر بیمه تکمیلی افرادغیر تحت تکفل");

                entity.Property(e => e.کسربیمهتکمیلیسرپرست).HasColumnName("کسر بیمه تکمیلی سرپرست");

                entity.Property(e => e.کسربیمهتکمیلیماهمعوقه).HasColumnName("کسر بیمه تکمیلی ماه معوقه");

                entity.Property(e => e.کمکهزینهرفاهی).HasColumnName("کمک هزینه رفاهی");
            });

            modelBuilder.Entity<KoshaTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kosha_Tax");

                entity.Property(e => e.جمعمزایا).HasColumnName("جمع مزایا");

                entity.Property(e => e.سال).HasColumnName("سال ");

                entity.Property(e => e.غیرمستمرمشمول).HasColumnName("غیر مستمر - مشمول");

                entity.Property(e => e.غیرمستمرمشمولوغیرمشمول).HasColumnName("غیر مستمر - مشمول و غیر مشمول");

                entity.Property(e => e.مزایایمشمول).HasColumnName("مزایای مشمول");

                entity.Property(e => e.مستمرحقوقپایهبنومسکنوحقاولاد).HasColumnName("مستمر - حقوق پایه بن و مسکن و حق اولاد");

                entity.Property(e => e.مستمرحقوقپایهوپایهسنوات).HasColumnName("مستمر - حقوق پایه و پایه سنوات");

                entity.Property(e => e.نامخانوادگی).HasColumnName("نام خانوادگی");

                entity.Property(e => e.کدملی).HasColumnName("کد ملی ");

                entity.Property(e => e.کدپرسنلی).HasColumnName("کد پرسنلی");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginAt)
                    .HasColumnName("Login_At")
                    .HasMaxLength(50);

                entity.Property(e => e.MacAddress)
                    .HasColumnName("Mac_Address")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<PortalSetting>(entity =>
            {
                entity.Property(e => e.PhoneNumberSupport).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
