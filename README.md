# State-Machine-Pattern
Each state is a class which have its own start and update(which are coroutines). Thus we don't need to check prev states to pass another state.
Each state starts its job with constructor.Thus we if we create a new State, it will start running. Only problem we can consider is Garbage Collector.
I'm trying to solve this issue now...
