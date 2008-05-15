package edu.wisc.doit.ls.coolit.view {
	
	import flare.vis.events.DataEvent;
	import flare.vis.data.Data;
	import flare.vis.data.DataList;
	
	/**
	  *
	  */
	public class CryoData extends Data {		
		
		/*
		 * Constructor
		 */
		public function CryoData(directedEdges_p:Boolean = false):void {
			super(directedEdges_p);
		}
		
		/**
		 * Removes all edges from this data set; updates all incident nodes.
		 */
		override public function clearEdges():void
		{
			var ea:Array = _edges.list, i:uint;
			//_edges.clear();
			
			for (i=0; i<ea.length; ++i) {
				fireEvent(DataEvent.DATA_REMOVED, ea[i]);
				ea[i].source = null;
				ea[i].target = null;
			}
			var nodes:Array = _nodes.list
			for (i=0; i<_nodes.size; ++i) {
				try {
					_nodes.list[i].removeAllEdges();
				} catch(e_p:Error) {
					//do nothing, just keep going
				}
				
			}
		}
	}
}