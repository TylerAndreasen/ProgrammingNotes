
Events exist as a way to execute code in other classes without needing to know what classes are being interacted with, and as such, any number of classes can respond to an Event.

Events can be represented in C# as Actions and Funcs.

	An Action operates largely as expected, and can be declared like the following:

		public Action<int> RocketShipDistanceEvent;

	The <int> specifies that when the Event RocketShipDistanceEvent is raised, an integer needs to be passed as an argument. No angle brackets are necessary if the Action does not need to include a parameter

	Actions can then be used like this:

	public void BroadcastRocketShipDistanceEvent(int distance)
	{
		RocketShipDistanceEvent?.Invoke(distance);
	}

	This method automatically invokes the event, but the ? before calling invoke is a oneline way to test if the Event has any subscribers. This is important as invoking an Event without any subscribers will throw an error, likely crashing a program.

Both of the above come from an explanation/tutorial linked below, and are actually made static in the example. This is because the goal of the video is to hammer home on the value of decoupling and show the usefulness of a Static Event Manager. Idea being, you have one class (or maybe a few to separate out different situations: UI, Combat, Dialogue, et cetera).

An important Note about Events broadly, events must be explicitly subscribed to before they are needed to function and should always be unsubscribed from when no longer necessary. This is because the subscription test mentioned before will still pass if a now freed object is still subscribed. This can be avoided by using -= in the _ExitTree() method in Godot.

Funcs are a tad different. The angle brackets are required after the Func keyword. The first (and possibly only) type specified in the angle brackets is the return type of the Func. I don't imagine that this is particularly useful, or at the least must be done with great care. In the case that multiple subscribers are listening to the event, getting multiple values returned in a Func could potentially be ignored, mangle each other, or simply crash the program. Depending on the actual behavior and thoughtful implementation this may be useful, but seems to be more trouble than it is worth.