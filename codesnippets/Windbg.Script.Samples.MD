### Printing all objects of given type
```java
	.foreach( dynamicMethod {!sos.dumpheap -type System.Reflection.Emit.DynamicMethod -short} )
	{
		!sos.do ${dynamicMethod}
	}
```