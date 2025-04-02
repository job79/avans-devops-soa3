using Domain.ProjectManagement;
using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Sprints;
using Task = Domain.ProjectManagement.Tasks.Task;
using Domain.Account;
using Domain.SourceManagement;
using Domain.Workflows;
using DomainServices.ProjectManagement.Subscribers;
using Infrastructure.Email;
using Infrastructure.Slack;
using Infrastructure.Workflows;

var tester = new Tester("Job", "Job@gmail.com");
var developer = new Developer("Thomas", "Thomas@gmail.com");
var scrumMaster = new ScrumMaster("Arno", "Arno@gmail.com");
var productOwner = new ProductOwner("Avans", "Avans@gmail.com");

var repository = new GitRepository("AvansDevops");

var project = new Project("Avans Devops", productOwner);
var sprint = new ReleaseSprint("test", DateTime.MaxValue, DateTime.MinValue, scrumMaster, repository);
project.Add(sprint);

var backlogitem = new BacklogItem("test3", "test3", 5, sprint, tester);
sprint.Add(backlogitem);
backlogitem.Add(new Task("test", "test"));
backlogitem.Developer = developer;

var backlogitem2 = new BacklogItem("test3", "test3", 3, sprint, tester);
sprint.Add(backlogitem2);
backlogitem2.Developer = developer;

var job1 = WorkflowJobFactory.Create("nunit-test", "settings", null);
var job2 = WorkflowJobFactory.Create("dotnet-build", "settings", job1);
var job3 = WorkflowJobFactory.Create("clone-source", "settings", job2);

var workflow = new Workflow(new List<WorkflowTrigger> { WorkflowTrigger.OnPush, WorkflowTrigger.OnRelease }, job3);
repository.Workflows.Add(workflow);

var emailAdapter = new EmailAdapter();
var slackAdapter = new SlackAdapter();
var productOwnerS = new SprintSubscriber(productOwner, slackAdapter);
var scrumMasterS = new SprintSubscriber(scrumMaster, slackAdapter);

sprint.Subscribe(productOwnerS);
sprint.Subscribe(scrumMasterS);

// var emailAdapter = new EmailAdapter();
// var slackAdapter = new SlackAdapter();
// var developerS = new BacklogItemSubscriber(developer, emailAdapter);
// var testerS = new BacklogItemSubscriber(tester, slackAdapter);
// var scrumMasterS = new BacklogItemSubscriber(scrumMaster, slackAdapter);
//
// backlogitem.Subscribe(developerS);
// backlogitem.Subscribe(testerS);
// backlogitem.Subscribe(scrumMasterS);
//
// backlogitem.ToDoing();
// backlogitem.ToReadyForTesting();
// backlogitem.ToTesting();
// backlogitem.ToTodo();
sprint.ToInProgress();
sprint.ToFinished();
sprint.ToRelease();

