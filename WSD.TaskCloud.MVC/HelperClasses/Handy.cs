using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.EF;


namespace WSD.TaskCloud.MVC.HelperClasses
{
    public static class Handy
    {
        public static void BindHierarchicalItem(List<Department> all, NodeViewModel parentNode)
        {

            List<Department> childs = all.Where(x => x.UpperDepartmentID == parentNode.Id).ToList();
            foreach (Department child in childs)
            {
                NodeViewModel childNode = new NodeViewModel() { Id = child.DepartmentID, Name = child.Name, Expanded = true };
                parentNode.Children.Add(childNode);
                BindHierarchicalItem(all, childNode);


            }


        }

        public static void GetSelectedNodes(List<NodeViewModel> selectedNodes, NodeViewModel parentNode)
        {

            foreach (var ch in parentNode.Children)
            {
                if (ch.IsChecked == true)
                    selectedNodes.Add(ch);

                GetSelectedNodes(selectedNodes, ch);
            }


        }

        public static void SetNode(NodeViewModel selectedNode, NodeViewModel parentNode, int id, bool isChecked)
        {
            if (parentNode.Id == id)
                selectedNode = parentNode;

            if (selectedNode != null)
            {
                parentNode.IsChecked = isChecked;
                selectedNode = parentNode;
                foreach (var ch in parentNode.Children)
                {
                    ch.IsChecked = isChecked;
                    SetNode(selectedNode, ch, id, isChecked);
                }

                return;
            }

            foreach (var ch in parentNode.Children)
            {
                SetNode(selectedNode, ch, id, isChecked);
            }

        }


        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }


    }
}