### Plain log4net config for file
```xml
    <log4net debug="false">

        <appender name="FileAppender" type="log4net.Appender.FileAppender">
            <file value="log.txt" />
            <appendToFile value="true" />
            <layout type="log4net.Layout.PatternLayout">
                <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
            </layout>
        </appender>

        <appender name="DebugOutput" type="log4net.Appender.TraceAppender">
            <layout type="log4net.Layout.PatternLayout">
                <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
            </layout>
        </appender>

        <root>
            <level value="DEBUG" />
            <appender-ref ref="FileAppender" />
            <!--<appender-ref ref="DebugOutput" />-->
        </root>

    </log4net>
```