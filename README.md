# Yargon Terms
**Yargon Terms** is the primary term library used by the Yargon language workbench. The terms represent a tree which is both a concrete and an abstract tree at the same time, and is represented as a directed acyclic graph of terms.

The terms are:

* immutable;<br />
  once you have a term, it can never change.
* shared;<br />
  simiar terms are shared in the tree, creating a DAG representation.
* concrete;<br />
  the syntax tokens are retained in the tree.
* abstract;<br />
  the concrete terms are implicitly kept around.
* printable;<br />
  thanks to the concrete terms, the tree can be used to reproduce the input exactly (including comments and whitespace).
* usable in code;<br />
  subclasses are used to create terms that provide a nice interface for code usage.
* serializable;<br />
  the terms can be serialized and deserialized.
* navigatable;<br />
  a temporary tree is constructed from the term graph whenever it is traversed, allowing code to traverse the tree both up and down.



## License
Copyright 2016, 2017 - Daniel Pelsmaeker

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at <http://www.apache.org/licenses/LICENSE-2.0>. Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
