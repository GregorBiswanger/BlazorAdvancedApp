using System.Reactive.Linq;
using System.Reactive.Subjects;

//var fruits = (new string[] { "apple", "apple", "banana", "apple" }).ToObservable();
//fruits.Distinct().Subscribe(x => Console.WriteLine(x));


var subject = new AsyncSubject<int>();

subject.OnNext(1);
subject.OnNext(2);
subject.Subscribe(data =>
{
    Console.WriteLine("Subscriber 1: " + data);
});


subject.OnNext(3);
subject.OnNext(4);

subject.Subscribe(data =>
{
    Console.WriteLine("Subscriber 2: " + data);
});

subject.OnNext(5);
subject.OnNext(6);

subject.OnCompleted();