#!/usr/bin/env python
# -*- coding: utf-8 -*-

# 裁剪掉任务脚本里的Sidequest

from xml.dom.minidom import parse, Node
import sys
import codecs


def trim_sidequest_dom(file_path):
  dom = parse(file_path)
  order = dom.getElementsByTagName('Order')[0]
  mark_delete_next = False
  print("order node count ", len(order.childNodes))
  for orderChild in order.childNodes:
    if orderChild.nodeType == Node.COMMENT_NODE and orderChild.nodeValue.strip().startswith('Sidequest'):
      mark_delete_next = True
    elif mark_delete_next == True and orderChild.nodeType == Node.ELEMENT_NODE:
      print("remove child ", orderChild, orderChild.nodeType)
      order.removeChild(orderChild)
      mark_delete_next = False

  print("after order node count ", len(order.childNodes))
  with codecs.open(file_path, "w", "utf-8") as out:
    dom.writexml(out, "  ", "  ")


if __name__ == '__main__':
  print(sys.argv[1])
  trim_sidequest_dom(sys.argv[1])
