using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS03.Migrations
{
    public partial class storedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //approved appointments in 2021
            var j = @"CREATE PROCEDURE sp_JanAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(j);
            var f = @"CREATE PROCEDURE sp_FebAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(f);
            var m = @"CREATE PROCEDURE sp_MarAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(m);
            var ap = @"CREATE PROCEDURE sp_AprAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(ap);
            var ma = @"CREATE PROCEDURE sp_MayAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(ma);
            var ju = @"CREATE PROCEDURE sp_JunAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(ju);
            var jul = @"CREATE PROCEDURE sp_JulAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(jul);
            var a = @"CREATE PROCEDURE sp_AugAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(a);
            var s = @"CREATE PROCEDURE sp_SepAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(s);
            var o = @"CREATE PROCEDURE sp_OctAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(o);
            var n = @"CREATE PROCEDURE sp_NovAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(n);
            var d = @"CREATE PROCEDURE sp_DecAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'  AND apptStatus = 'Approved'
                          END";
            migrationBuilder.Sql(d);

            //Cancelled appointments in 2021

            var q = @"CREATE PROCEDURE sp_JanC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(q);
            var w = @"CREATE PROCEDURE sp_FebC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(w);
            var e = @"CREATE PROCEDURE sp_MarC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(e);
            var r = @"CREATE PROCEDURE sp_AprC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(r);
            var t = @"CREATE PROCEDURE sp_MayC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(t);
            var y = @"CREATE PROCEDURE sp_JunC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(y);
            var u = @"CREATE PROCEDURE sp_JulC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(u);
            var i = @"CREATE PROCEDURE sp_AugC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(i);
            var p = @"CREATE PROCEDURE sp_SepC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(p);
            var g = @"CREATE PROCEDURE sp_OctC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(g);
            var h = @"CREATE PROCEDURE sp_NovC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(h);
            var k = @"CREATE PROCEDURE sp_DecC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'  AND apptStatus = 'Cancelled'
                          END";
            migrationBuilder.Sql(k);

            //appointments made in 2021

            var sqler = @"CREATE PROCEDURE sp_JanStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'
                      END";
            migrationBuilder.Sql(sqler);
            var sqle = @"CREATE PROCEDURE sp_FebStats
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'
                          END";
            migrationBuilder.Sql(sqle);
            var sql = @"CREATE PROCEDURE sp_MarStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'
                      END";
            migrationBuilder.Sql(sql);

            var sq = @"CREATE PROCEDURE sp_AprStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'
                      END";
            migrationBuilder.Sql(sq);

            var data = @"CREATE PROCEDURE sp_MaybStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'
                      END";
            migrationBuilder.Sql(data);

            var dat = @"CREATE PROCEDURE sp_JunStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'
                      END";
            migrationBuilder.Sql(dat);

            var inf = @"CREATE PROCEDURE sp_JulStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'
                      END";
            migrationBuilder.Sql(inf);

            var x = @"CREATE PROCEDURE sp_AugStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-30'
                      END";
            migrationBuilder.Sql(x);

            var ik = @"CREATE PROCEDURE sp_SeptStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'
                      END";
            migrationBuilder.Sql(ik);

            var sk = @"CREATE PROCEDURE sp_OctStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'
                      END";
            migrationBuilder.Sql(sk);

            var nk = @"CREATE PROCEDURE sp_NovStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'
                      END";
            migrationBuilder.Sql(nk);

            var dec = @"CREATE PROCEDURE sp_DecStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'
                      END";
            migrationBuilder.Sql(dec);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apr");

            migrationBuilder.DropTable(
                name: "Aug");

            migrationBuilder.DropTable(
                name: "Dec");

            migrationBuilder.DropTable(
                name: "Feb");

            migrationBuilder.DropTable(
                name: "Jan");

            migrationBuilder.DropTable(
                name: "Jul");

            migrationBuilder.DropTable(
                name: "Jun");

            migrationBuilder.DropTable(
                name: "Mar");

            migrationBuilder.DropTable(
                name: "May");

            migrationBuilder.DropTable(
                name: "Nov");

            migrationBuilder.DropTable(
                name: "Oct");

            migrationBuilder.DropTable(
                name: "Sep");
        }
    }
}
