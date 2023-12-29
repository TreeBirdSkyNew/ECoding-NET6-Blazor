using E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_DAL
{
    public static class DbInitializer
    {
        public static void Initialize(TemplateProjectDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TemplateProject.Any())
            {
                return;   // DB has been seeded
            }

            /*******************TemplateSolution*************************/
            InitializeTemplateSolution(context);

            /*******************TemplateProject*************************/
            InitializeTemplateProject(context);

            /*******************TemplateTechnique***********************/
            InitializeTemplateTechnique(context);

            /*******************TemplateResult*********************/
            InitializeTemplateResult(context);
        }

        public static void InitializeTemplateSolution(TemplateProjectDbContext context)
        {
            var templateSolutions = new TemplateSolution[]
            {
                new TemplateSolution()
                {
                    TemplateSolutionId=1,
                    TemplateProjectId = 1,
                    TemplateSolutionDescription = "TemplateSolutionDescription1",
                    TemplateSolutionName = "TemplateSolutionName1",
                    TemplateSolutionTitle = "TemplateSolutionTitle1",
                    TemplateSolutionVersion = "TemplateSolutionVersion1",
                    TemplateSolutionVersionNet = "TemplateSolutionVersionNet1"
                }
            };
            foreach (TemplateSolution solution in templateSolutions)
            {
                context.TemplateSolution.Add(solution);
            }
            context.SaveChanges();
        }
        public static void InitializeTemplateProject(TemplateProjectDbContext context)
        {
            var templateProjects = new TemplateProject[]
            {
                new TemplateProject()
                {
                    TemplateProjectId = 1,
                    TemplateProjectDescription = "TemplateProjectDescription1",
                    TemplateProjectName = "TemplateProjectName1",
                    TemplateProjectTitle = "TemplateProjectTitle1",
                    TemplateProjectVersion = "TemplateProjectVersion1",
                    TemplateProjectVersionNet = "TemplateProjectVersionNet1",
                    
                },
                new TemplateProject()
                {
                    TemplateProjectId = 2,
                    TemplateProjectDescription = "TemplateProjectDescription2",
                    TemplateProjectName = "TemplateProjectName2",
                    TemplateProjectTitle = "TemplateProjectTitle2",
                    TemplateProjectVersion = "TemplateProjectVersion2",
                    TemplateProjectVersionNet = "TemplateProjectVersionNet2",
                    
                }
            };
            foreach (TemplateProject project in templateProjects)
            {
                context.TemplateProject.Add(project);
            }
            context.SaveChanges();
        }

        public static void InitializeTemplateTechnique(TemplateProjectDbContext context)
        {
            var templateTechniques = new TemplateTechnique[]
            {
                new TemplateTechnique
                {
                    TemplateTechniqueId = 1,
                    TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                    TemplateTechniqueName = "TemplateTechniqueName1",
                    TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                    TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                    TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                    TemplateProjectId = 1
                },
                new TemplateTechnique
                {
                    TemplateTechniqueId = 2,
                    TemplateTechniqueDescription = "TemplateTechniqueDescription2",
                    TemplateTechniqueName = "TemplateTechniqueName2",
                    TemplateTechniqueTitle = "TemplateTechniqueTitle2",
                    TemplateTechniqueVersion = "TemplateTechniqueVersion2",
                    TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET2",
                    TemplateProjectId = 1
                }
            };
            foreach (TemplateTechnique technique in templateTechniques)
            {
                context.TemplateTechnique.Add(technique);
            }
            context.SaveChanges();

            var templateTechniqueItems = new TemplateTechniqueItem[]
            {
                new TemplateTechniqueItem
                {
                    TemplateTechniqueItemId = 1,
                    TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                    TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                    TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                    TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1",
                    TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
                    TemplateTechniqueId = 1
                }
            };
            foreach (TemplateTechniqueItem techniqueItem in templateTechniqueItems)
            {
                context.TemplateTechniqueItem.Add(techniqueItem);
            }
            context.SaveChanges();
        }

        

        public static void InitializeTemplateResult(TemplateProjectDbContext context)
        {
            var TemplateResults = new List<TemplateResult>
            {
                new TemplateResult
                {
                    TemplateResultId = 1,
                    TemplateProjectId = 1,
                    TemplateResultDescription = "TemplateResultDescription",
                    TemplateResultName = "TemplateResultName",
                    TemplateResultTitle = "TemplateResultTitle",
                    TemplateResultVersion = "TemplateResultVersion",
                    TemplateResultVersionNET = "TemplateResultVersionNET",
                    TemplateResultItem=new List<TemplateResultItem>
                    {
                        new TemplateResultItem
                        {
                            TemplateResultItemId = 1,
                            TemplateResultItemDescription = "TemplateResultItemDescription",
                            TemplateResultItemName = "TemplateResultItemName",
                            TemplateResultItemTitle = "TemplateResultItemTitle",
                            TemplateResultItemVersion = "TemplateResultItemVersion",
                            TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                            TemplateTechniqueId = 1,
                            TemplateFonctionnelId = 1,
                            TemplateResultId = 1,
                            TemplateResultFinalContent = "TemplateResultFinalContent",
                            TemplateResultInitialContent = "TemplateResultInitialContent"
                        },
                        new TemplateResultItem
                        {
                            TemplateResultItemId = 2,
                            TemplateResultItemDescription = "TemplateResultItemDescription",
                            TemplateResultItemName = "TemplateResultItemName",
                            TemplateResultItemTitle = "TemplateResultItemTitle",
                            TemplateResultItemVersion = "TemplateResultItemVersion",
                            TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                            TemplateTechniqueId = 1,
                            TemplateFonctionnelId = 1,
                            TemplateResultId = 2,
                            TemplateResultFinalContent = "TemplateResultFinalContent",
                            TemplateResultInitialContent = "TemplateResultInitialContent"
                        }
                    }
                },
                new TemplateResult
                {
                    TemplateResultId = 2,
                    TemplateProjectId = 1,
                    TemplateResultDescription = "TemplateResultDescription",
                    TemplateResultName = "TemplateResultName",
                    TemplateResultTitle = "TemplateResultTitle",
                    TemplateResultVersion = "TemplateResultVersion",
                    TemplateResultVersionNET = "TemplateResultVersionNET"
                }
            };
        }
    }
}



