```xml
 <TreeView ItemsSource="{Binding RootConfigurations}">
            <TreeView.Resources>

                <HierarchicalDataTemplate DataType="{x:Type viewModel:WorkInProgressCommandTreeViewModel}"  ItemsSource="{Binding Children}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </HierarchicalDataTemplate>


				<HierarchicalDataTemplate DataType="{x:Type viewModels:DataViewMode}"  ItemsSource="{Binding Children}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}">
                        </TextBlock>

                        <StackPanel Style="{StaticResource CountVisibilityStyle}" Orientation="Horizontal">
                            <TextBlock Text="(" />
                            <TextBlock Text="{Binding ChildCount}" />
                            <TextBlock Text=")" />
                        </StackPanel>

                        <StackPanel.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="MenuItemHere" Command="{Binding Path=ExportCommand}"/>
							</ContextMenu>
                        </StackPanel.ContextMenu>

                    </StackPanel>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
        </TreeView>
```