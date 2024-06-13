<script lang="ts">
    import Hexagon from './Hexagon.svelte';
    import type { Hexagon2D } from './models/Hexagon2D';
  
    export let size: number;

    export let hexes:Hexagon2D[] = [];
    console.log(111);
    console.log(hexes);


    /*
     In the  orientation, the horizontal distance between
     adjacent hexagons centers is horiz = 3/4 * width = 3/2 * size. The vertical distance is vert = height = sqrt(3) * size.
    */

    /* pointy top
     In the  orientation, the horizontal distance between adjacent
      hexagon centers is horiz = width = sqrt(3) * size.
      The vertical distance is vert == 3/4 * height == 3/2 * size.
    */
  
    //popinty top
    const sqrt3 = Math.sqrt(3);
    const hexHoriz = sqrt3 * size;
    const hexVert = 3 / 2 * size;

  </script>
  
  <div class="hex-grid">
    {#each hexes as hex}
        <Hexagon size={size} position={hex.position}
          x={hex.position.x * hexHoriz + (hex.position.y % 2 == 0 ? 0 : hexHoriz / 2)}
          y={hex.position.y * hexVert}/>
    
    {/each}
  </div>
  
  <style>
    .hex-grid {
      display: flex;
      flex-wrap: wrap;
      position: relative;
    }
    .hex-grid > :global(svg) {
      position: absolute;
    }
  </style>
  