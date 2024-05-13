using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VTU_Manager.Domain.Entities;
using VTU_Manager.Domain.Enums;

namespace VTU_Manager.Persistance.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<VTUser> userManager, RoleManager<VTRole> roleManager)
        {
            var administratorRole = new VTRole("Administrator");
            var userRole = new VTRole("User");
            var affirmRole = new VTRole("Affirmator");
            var supervisorRole = new VTRole("Supervisor");
            var editorRole = new VTRole("Editor");

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(administratorRole);
                await roleManager.CreateAsync(userRole);
                await roleManager.CreateAsync(affirmRole);
                await roleManager.CreateAsync(supervisorRole);
                await roleManager.CreateAsync(editorRole);
            }

            var administrator = new VTUser { UserName = "administrator", Email = "administrator@uni-vt.com" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name, userRole.Name });
            }
        }

        public static async Task SeedDepartments(ApplicationDbContext context)
        {
            if (!context.Departments.Any())
            {
                await context.Departments.AddRangeAsync(new List<Department>()
                {
                    new Department { DepartmentName = DepartmentsEnum.Враца },
                    new Department { DepartmentName = DepartmentsEnum.Издателство },
                    new Department { DepartmentName = DepartmentsEnum.Изобразително },
                    new Department { DepartmentName = DepartmentsEnum.Исторически },
                    new Department { DepartmentName = DepartmentsEnum.Колеж },
                    new Department { DepartmentName = DepartmentsEnum.Педагогически },
                    new Department { DepartmentName = DepartmentsEnum.Православен },
                    new Department { DepartmentName = DepartmentsEnum.Стопански },
                    new Department { DepartmentName = DepartmentsEnum.Филология },
                    new Department { DepartmentName = DepartmentsEnum.Философия },
                    new Department { DepartmentName = DepartmentsEnum.ФМИ },
                    new Department { DepartmentName = DepartmentsEnum.Юридически }
                });

                await context.SaveChangesAsync();
            }
        }


        public static async Task SeedEligibleEmails(ApplicationDbContext context)
        {
            var departments = new List<Department>();

            foreach (DepartmentsEnum department in Enum.GetValues(typeof(DepartmentsEnum)))
            {
                departments.Add(new Department() { DepartmentName = department });
            }

            var prAccess = new List<ProjectAccess>()
                {
                    new ProjectAccess()
                    {
                        ProjectsAccess=ProjectsAccessEnum.Projects
                    },
                    new ProjectAccess()
                    {
                        ProjectsAccess=ProjectsAccessEnum.Plagiat
                    },
                    new ProjectAccess()
                    {
                        ProjectsAccess=ProjectsAccessEnum.Nacid
                    }
                };
            if (!context.Departments.Any())
            {
                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }
            if (!context.ProjectAccesses.Any())
            {
                await context.ProjectAccesses.AddRangeAsync(prAccess);
                await context.SaveChangesAsync();
            }

            if (!context.EligableEmails.Any())
            {
                await context.EligableEmails.AddRangeAsync(new List<EligibleEmail>()
                {
                    new EligibleEmail { Email = "nickolay@gmail.bg",IsDean=true,Department=departments[0] },
                    new EligibleEmail { Email = "valentin@gmail.bg",IsHeadOfDepartment=true,Department=departments[2] },
                    new EligibleEmail { Email = "daniel@gmail.com",IsScientificSecretary=true,Department=departments[3] },
                    new EligibleEmail { Email = "daniela.tsoneva@uni-vt.bg",IsSupervisor=true,Department=departments[5] },
                    new EligibleEmail { Email = "m.ilcheva@uni-vt.bg",IsViceDean=true,Department=departments[1] },
                });

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedRerervedDropdowns(ApplicationDbContext context)
        {
            List<DropDownSource> dropdownSources = await context.DropDawnSources.ToListAsync();

            if (!dropdownSources.Any())
            {
                var reservedDropdowns = new List<DropDownSource>()
                {
                    new DropDownSource()
                    {
                        SourceName = "Link",
                        IsActive = true,
                        IsReserved = true,
                        Items = new List<DropDownItem>()
                        {
                            new DropDownItem()
                            {
                                Label = "ФМИ",
                                Code = "01",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Филологически факлутет",
                                Code = "02",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Стопански факлутет",
                                Code = "03",
                                IsReserved = true
                            },new DropDownItem()
                            {
                                Label = "Природо-исторически факлутет",
                                Code = "04",
                                IsReserved = true
                            }
                        }
                    },
                    new DropDownSource()
                    {
                        SourceName = "RoleForVTU",
                        IsActive = true,
                        IsReserved = true,
                        Items = new List<DropDownItem>()
                        {
                            new DropDownItem()
                            {
                                Label = "Водеща организация",
                                Code = "05",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Второстепенна организация",
                                Code = "06",

                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Трета страна",
                                Code = "07",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Неутрална",
                                Code = "08",
                                IsReserved = true
                            }
                        }
                    },
                    new DropDownSource()
                    {
                        SourceName = "ProjectStatus",
                        IsActive = true,
                        IsReserved = true,
                        Items = new List<DropDownItem>()
                        {
                            new DropDownItem()
                            {
                                Label = "Новосъздаден",
                                Code = "09",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "В процес на разработка",
                                Code = "10",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "В процес на разглеждане и оценка",
                                Code = "11",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Закрит",
                                Code = "12",
                                IsReserved = true
                            }
                        }
                    },
                    new DropDownSource()
                    {
                        SourceName = "LeadingOrganizationCountry",
                        IsActive = true,
                        IsReserved = true,
                        Items = new List<DropDownItem>()
                        {
                            new DropDownItem()
                            {
                                Label = "България",
                                Code = "13",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Република Северна Македония",
                                Code = "14",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Гърция",
                                Code = "15",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "Сърбия",
                                Code = "16",
                                IsReserved = true
                            }
                        }
                    },
                    new DropDownSource()
                    {
                        SourceName = "Currency",
                        IsActive = true,
                        IsReserved = true,
                        Items = new List<DropDownItem>()
                        {
                            new DropDownItem()
                            {
                                Label = "BGN",
                                Code = "17",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "EUR",
                                Code = "18",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "USD",
                                Code = "19",
                                IsReserved = true
                            },
                            new DropDownItem()
                            {
                                Label = "GBP",
                                Code = "20",
                                IsReserved = true
                            }
                        }
                    }
                };

                await context.DropDawnSources.AddRangeAsync(reservedDropdowns);
                await context.SaveChangesAsync();
            }
        }
    }
}
