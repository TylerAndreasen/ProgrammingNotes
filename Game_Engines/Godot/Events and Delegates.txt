Watching the video below made things significantly more clear
https://www.youtube.com/watch?v=jQgwEsJISy0

Decoupling is a design goal that aims to have code rely on other code as
little as possible. This is because if a change must be made to a Core class
which is dependent on/descended from by many other classes, all of those
classes must be recompiled and redeployed anytime a change is made.

An Event is a way to decouple communication between different Classes and Objects. An Event is a kind of shout into the wind of an object or class, done
regardless of and without knowledge of any class or object listening to the
Event.

Things which raise Events are called Publishers, and those that handle events are called Subscribers.

But Events alone, just fancy methods, are not enough to truly decouple classes and objects from each other.

Delegates act as an agreement or contract between Publishers and Subscribers,
and determines the Signature of the method in the Subscriber that is called
when the Event is published.


How To:

1. Define a Delegate - within the Publisher, this determines the requirements
of the method in the Subscriber which will be called.

2. Define an Event - within the Publisher, this is what happens that we are
interested in notifying others about.

3. Raise an Event - 