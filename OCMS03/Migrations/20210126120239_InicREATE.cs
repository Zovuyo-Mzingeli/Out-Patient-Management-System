using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS03.Migrations
{
    public partial class InicREATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMedication",
                columns: table => new
                {
                    MedicationId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    RegistryNo = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ActiveIngredients = table.Column<string>(nullable: false),
                    StrengthOrPacksize = table.Column<string>(nullable: false),
                    PackSize = table.Column<string>(nullable: false),
                    Form = table.Column<string>(nullable: false),
                    Schedule = table.Column<string>(nullable: false),
                    QuantityAndLimitation = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    MedExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedication", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "tblProvince",
                columns: table => new
                {
                    ProvinceId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProvince", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "tblWalkIn",
                columns: table => new
                {
                    WalkInId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Dob = table.Column<DateTime>(nullable: false),
                    Idnumber = table.Column<string>(maxLength: 13, nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    NextOfName = table.Column<string>(nullable: true),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: true),
                    Relationship = table.Column<string>(maxLength: 50, nullable: true),
                    NextOfKinNumber = table.Column<string>(maxLength: 13, nullable: true),
                    VistingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWalkIn", x => x.WalkInId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDistrict",
                columns: table => new
                {
                    DistrictId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDistrict", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_tblDistrict_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCity",
                columns: table => new
                {
                    CityId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    CityName = table.Column<string>(maxLength: 50, nullable: false),
                    DistrictId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCity", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_tblCity_tblDistrict_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "tblDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblClinic",
                columns: table => new
                {
                    ClinicId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    ClinicName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 250, nullable: true),
                    CityId = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 6, nullable: false),
                    Telephone = table.Column<string>(maxLength: 13, nullable: false),
                    FaxNumber = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClinic", x => x.ClinicId);
                    table.ForeignKey(
                        name: "FK_tblClinic_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblClinic_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblHospital",
                columns: table => new
                {
                    HospitalId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    HospitalName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 250, nullable: true),
                    CityId = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 6, nullable: false),
                    Telephone = table.Column<string>(maxLength: 13, nullable: false),
                    FaxNumber = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHospital", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_tblHospital_tblCity",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblHospital_tblProvince",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalId = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    FaxNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tblDepartment_tblHospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Idnumber = table.Column<string>(maxLength: 13, nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(maxLength: 50, nullable: true),
                    Specialization = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentId = table.Column<string>(maxLength: 50, nullable: true),
                    HospitalId = table.Column<string>(maxLength: 50, nullable: true),
                    ClinicId = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 250, nullable: true),
                    ProvinceId = table.Column<string>(maxLength: 50, nullable: true),
                    CityId = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 6, nullable: true),
                    NextOfName = table.Column<string>(maxLength: 50, nullable: true),
                    NextOfKinSurname = table.Column<string>(maxLength: 50, nullable: true),
                    Relationship = table.Column<string>(maxLength: 50, nullable: true),
                    NextOfKinNumber = table.Column<string>(maxLength: 13, nullable: true),
                    IsResetPasswordRequired = table.Column<bool>(nullable: true),
                    UserStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblCity_CityId",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblClinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "tblClinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblHospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAllergy",
                columns: table => new
                {
                    AllergyId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    AllergyTypeName = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllergy", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_tblAllergy_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAppointment",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    AppointmentDescription = table.Column<string>(maxLength: 250, nullable: false),
                    isConfirmed = table.Column<bool>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    NurseId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: false),
                    HospitalId = table.Column<string>(nullable: true),
                    ClinicId = table.Column<string>(nullable: false),
                    WalkInId = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    apptStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAppointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblClinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "tblClinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAppointment_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblHospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "tblHospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_AspNetUsers_NurseId",
                        column: x => x.NurseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblWalkIn_WalkInId",
                        column: x => x.WalkInId,
                        principalTable: "tblWalkIn",
                        principalColumn: "WalkInId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPatient_Medication",
                columns: table => new
                {
                    Patient_MedsId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    PatientId = table.Column<string>(nullable: true),
                    PharmacistId = table.Column<string>(nullable: true),
                    MedsReceived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient_Medication", x => x.Patient_MedsId);
                    table.ForeignKey(
                        name: "FK_tblPatient_Medication_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatient_Medication_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPatientVitals",
                columns: table => new
                {
                    VitalsId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: false),
                    Temperature = table.Column<string>(nullable: false),
                    Pulse = table.Column<string>(nullable: false),
                    RepertoryRate = table.Column<string>(nullable: false),
                    BloodPressure = table.Column<string>(nullable: false),
                    Height = table.Column<string>(nullable: false),
                    Weight = table.Column<string>(nullable: false),
                    BMI = table.Column<string>(nullable: false),
                    PainScore = table.Column<string>(nullable: false),
                    SPO2 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatientVitals", x => x.VitalsId);
                    table.ForeignKey(
                        name: "FK_tblPatientVitals_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatientVitals_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPrescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    PatientId = table.Column<string>(nullable: false),
                    PharmacistId = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PrescriptionNotes = table.Column<string>(maxLength: 1000, nullable: true),
                    SeenByPharmacist = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_tblPrescription_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPrescription_AspNetUsers_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPrescription_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblReferral",
                columns: table => new
                {
                    ReferralId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    PatientId = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: false),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    ReferalDescriptin = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReferral", x => x.ReferralId);
                    table.ForeignKey(
                        name: "FK_tblReferral_tblDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReferral_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReferral_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPatientAllergyDiagnosis",
                columns: table => new
                {
                    PatientAllergyDiagnosisId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    CheckedDate = table.Column<DateTime>(nullable: false),
                    AllergyId = table.Column<string>(nullable: false),
                    PhysicalExamNotes = table.Column<string>(nullable: true),
                    AllergyDiagnoseTestType = table.Column<string>(nullable: true),
                    AllergySymptoms = table.Column<string>(nullable: false),
                    PatientId = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatientAllergyDiagnosis", x => x.PatientAllergyDiagnosisId);
                    table.ForeignKey(
                        name: "FK_tblPatientAllergyDiagnosis_tblAllergy_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "tblAllergy",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPatientAllergyDiagnosis_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPatientAllergyDiagnosis_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDiagnosis",
                columns: table => new
                {
                    DiagnosisCode = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    PatientId = table.Column<string>(nullable: false),
                    StaffId = table.Column<string>(nullable: false),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    ExaminationNotes = table.Column<string>(nullable: false),
                    AppointmentId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiagnosis", x => x.DiagnosisCode);
                    table.ForeignKey(
                        name: "FK_tblDiagnosis_tblAppointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "tblAppointment",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDiagnosis_tblDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDiagnosis_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDiagnosis_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCartLine",
                columns: table => new
                {
                    Patient_PrescriptionId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Dose = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Morning = table.Column<bool>(nullable: false),
                    Afternoon = table.Column<bool>(nullable: false),
                    Evening = table.Column<bool>(nullable: false),
                    PrescriptionId = table.Column<string>(nullable: true),
                    MedicationId = table.Column<string>(nullable: true),
                    Patient_MedicationPatient_MedsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartLine", x => x.Patient_PrescriptionId);
                    table.ForeignKey(
                        name: "FK_tblCartLine_tblMedication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "tblMedication",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCartLine_tblPatient_Medication_Patient_MedicationPatient_MedsId",
                        column: x => x.Patient_MedicationPatient_MedsId,
                        principalTable: "tblPatient_Medication",
                        principalColumn: "Patient_MedsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCartLine_tblPrescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "tblPrescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProvinceId",
                table: "AspNetUsers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllergy_ApplicationUserId",
                table: "tblAllergy",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_ClinicId",
                table: "tblAppointment",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_DoctorId",
                table: "tblAppointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_HospitalId",
                table: "tblAppointment",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_NurseId",
                table: "tblAppointment",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_PatientId",
                table: "tblAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_WalkInId",
                table: "tblAppointment",
                column: "WalkInId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartLine_MedicationId",
                table: "tblCartLine",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartLine_Patient_MedicationPatient_MedsId",
                table: "tblCartLine",
                column: "Patient_MedicationPatient_MedsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartLine_PrescriptionId",
                table: "tblCartLine",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCity_DistrictId",
                table: "tblCity",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClinic_CityId",
                table: "tblClinic",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClinic_ProvinceId",
                table: "tblClinic",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartment_HospitalId",
                table: "tblDepartment",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiagnosis_AppointmentId",
                table: "tblDiagnosis",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiagnosis_DepartmentId",
                table: "tblDiagnosis",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiagnosis_PatientId",
                table: "tblDiagnosis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiagnosis_StaffId",
                table: "tblDiagnosis",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDistrict_ProvinceId",
                table: "tblDistrict",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHospital_CityId",
                table: "tblHospital",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHospital_ProvinceId",
                table: "tblHospital",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_Medication_PatientId",
                table: "tblPatient_Medication",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatient_Medication_PharmacistId",
                table: "tblPatient_Medication",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientAllergyDiagnosis_AllergyId",
                table: "tblPatientAllergyDiagnosis",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientAllergyDiagnosis_PatientId",
                table: "tblPatientAllergyDiagnosis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientAllergyDiagnosis_StaffId",
                table: "tblPatientAllergyDiagnosis",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVitals_PatientId",
                table: "tblPatientVitals",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatientVitals_StaffId",
                table: "tblPatientVitals",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescription_PatientId",
                table: "tblPrescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescription_PharmacistId",
                table: "tblPrescription",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescription_StaffId",
                table: "tblPrescription",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReferral_DepartmentId",
                table: "tblReferral",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReferral_PatientId",
                table: "tblReferral",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReferral_StaffId",
                table: "tblReferral",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblCartLine");

            migrationBuilder.DropTable(
                name: "tblClaims");

            migrationBuilder.DropTable(
                name: "tblDiagnosis");

            migrationBuilder.DropTable(
                name: "tblPatientAllergyDiagnosis");

            migrationBuilder.DropTable(
                name: "tblPatientVitals");

            migrationBuilder.DropTable(
                name: "tblReferral");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblMedication");

            migrationBuilder.DropTable(
                name: "tblPatient_Medication");

            migrationBuilder.DropTable(
                name: "tblPrescription");

            migrationBuilder.DropTable(
                name: "tblAppointment");

            migrationBuilder.DropTable(
                name: "tblAllergy");

            migrationBuilder.DropTable(
                name: "tblWalkIn");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblClinic");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblHospital");

            migrationBuilder.DropTable(
                name: "tblCity");

            migrationBuilder.DropTable(
                name: "tblDistrict");

            migrationBuilder.DropTable(
                name: "tblProvince");
        }
    }
}
