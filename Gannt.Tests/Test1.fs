module Gannt.Tests

open System
open System.Collections.Generic
open Xunit
open Swensen.Unquote

type TaskId = string

type TaskConstraint =
    | Effort of int
    | MustStartAfter of DateOnly

type DependencyType = | FinishToStart

type TaskDependency =
    { FromTask: TaskId
      ToTask: TaskId
      DependencyType: DependencyType }

type Task =
    { Id: TaskId
      Name: string
      Constraints: TaskConstraint list
      Dependencies: TaskDependency list }

type Project = { Tasks: Task list }


let BASE_DATE = DateOnly(2025, 08, 15)

type TaskSchedule =
    { Id: TaskId
      StartDate: DateOnly
      EndDate: DateOnly }

type ProjectSchedule =
    { TaskSchedules: Dictionary<TaskId, TaskSchedule> }

// Implement a function that calculates task schedules for a given project
let calculateProjectSchedule (project: Project) : TaskSchedule list =
    // todo 1: construct the graph of tasks and dependencies

    raise (NotImplementedException())

[<Fact>]
let ``Minimal finish to start example`` () =
    let proj =
        { Tasks =
            [ { Id = "1"
                Name = "Task 1"
                Constraints = [ Effort 3 ]
                Dependencies = [] }
              { Id = "2"
                Name = "Task 2"
                Constraints = [ MustStartAfter(BASE_DATE) ]
                Dependencies =
                  [ { FromTask = "1"
                      ToTask = "2"
                      DependencyType = FinishToStart } ] } ] }

    let projSchedule = calculateProjectSchedule proj

    test <@ true @>
