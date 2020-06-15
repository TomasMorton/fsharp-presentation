module FSharp.TestSamples.ImprovedDateRangeTests

open System
open System.Linq
open FsCheck
open FsCheck.Xunit
open FsUnit.Xunit
open CSharp.Dependencies

module FromValuesShould =
    let propertyName = "DateRange"

    let fromValues (startDate : DateTime) endDate =
        DateRange.FromValues(startDate, endDate, propertyName)
    
    [<Property>]
    let ``Succeed when the Start Date is earlier than the End Date``
        (startDate: DateTime)
        (endDate: DateTime) =
        (startDate < endDate) ==> lazy

        let dateRange = fromValues startDate endDate
        dateRange.IsOk |> should be True
        dateRange.Value.Start |> should equal startDate
        dateRange.Value.End |> should equal endDate

    [<Property>]
    let ``Fail when the End Date is earlier than the Start Date``
        (startDate: DateTime)
        (endDate: DateTime) =
        (endDate < startDate) ==> lazy

        let dateRange = fromValues startDate endDate
        dateRange.IsOk |> should be False
        dateRange.Errors |> should haveCount 1
        dateRange.Errors.First().Message |> should equal "Invalid date range"
            
    [<Property>]
    let ``Succeed when the Start Date is the same as the End Date``
        (startDate: DateTime) =
        let endDate = startDate
        
        let dateRange = fromValues startDate endDate
        dateRange.IsOk |> should be True
        dateRange.Value.Start |> should equal startDate
        dateRange.Value.End |> should equal endDate


//public class DateRangeTests
//{
//    [Fact]
//    public void DateRange_FromValues_SucceedsWhenStartEarlierThanEnd()
//    {
//        DateTime start = new DateTime(2018,09,19);
//        DateTime end = new DateTime(2018,09,30);
//        Result<DateRange> dateRange = DateRange.FromValues(start, end, "DateRange");
//        Assert.True(dateRange.IsOk);
//        Assert.Equal(dateRange.Value.Start, start);
//        Assert.Equal(dateRange.Value.End, end);
//    }
//
//    [Fact]
//    public void DateRange_FromValues_FailsWhenEndEarlierThanStart()
//    {
//        DateTime start = new DateTime(2018,09,30);
//        DateTime end = new DateTime(2018,09,19);
//        Result<DateRange> dateRange = DateRange.FromValues(start, end, "DateRange");
//        Assert.False(dateRange.IsOk);
//        Assert.Null(dateRange.Value);
//        Assert.Equal(dateRange.Errors.Count(), 1);
//        Assert.Equal(dateRange.Errors.First().Message, "Invalid date range");
//    }
//
//    [Fact]
//    public void DateRange_FromValues_SucceedsWhenStartSameAsEnd()
//    {
//        DateTime start = new DateTime(2018,09,19);
//        DateTime end = new DateTime(2018,09,19);
//        Result<DateRange> dateRange = DateRange.FromValues(start, end, "DateRange");
//        Assert.True(dateRange.IsOk);
//        Assert.Equal(dateRange.Value.Start, start);
//        Assert.Equal(dateRange.Value.End, end);
//    }
//}
