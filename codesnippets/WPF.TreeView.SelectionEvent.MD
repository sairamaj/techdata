### Tree view selected change event
```xml
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="IsSelected" Value="{Binding IsSelected}" />
                </Style>
            </TreeView.ItemContainerStyle>

```