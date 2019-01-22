﻿using Umbraco.Core;
using Umbraco.Core.IO;
using Umbraco.Web.Composing;
using Umbraco.Web.Models.Trees;

namespace Umbraco.Web.Trees
{
    [CoreTree]
    [Tree(Constants.Applications.Settings, Constants.Trees.Scripts, TreeTitle = "Scripts", IconOpen = "icon-folder", IconClosed = "icon-folder", SortOrder = 10, TreeGroup = Constants.Trees.Groups.Templating)]
    public class ScriptsTreeController : FileSystemTreeController
    {
        protected override IFileSystem FileSystem => Current.FileSystems.ScriptsFileSystem; // todo inject

        private static readonly string[] ExtensionsStatic = { "js" };

        protected override string[] Extensions => ExtensionsStatic;

        protected override string FileIcon => "icon-script";

        protected override void OnRenderFolderNode(ref TreeNode treeNode)
        {
            //TODO: This isn't the best way to ensure a noop process for clicking a node but it works for now.
            treeNode.AdditionalData["jsClickCallback"] = "javascript:void(0);";
        }
    }
}
