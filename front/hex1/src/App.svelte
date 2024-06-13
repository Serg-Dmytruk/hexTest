<script lang="ts">
  import HexGrid from "./HexGrid.svelte";
  import { GameFieldRequest } from "./models/GameFieldRequest";
  import { Hexagon2D } from "./models/Hexagon2D";
  import { getApiConnection } from "./services/EnvService";

  let gameFieldRequest: GameFieldRequest = new GameFieldRequest();
  let hexGrid: Hexagon2D[] = [];

  async function request() {
    try {
      const response = await fetch("https://localhost:5280/game/create", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(gameFieldRequest),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const result = await response.json();
      hexGrid = result.gameField;

    } catch (err) {
      console.log(err);
    }
    
    console.log(hexGrid);
    console.log(hexGrid.length);
   
  }
</script>

<!-- svelte-ignore a11y-label-has-associated-control -->
<label>width:</label>
<input type="number" bind:value="{gameFieldRequest.width}" />

<!-- svelte-ignore a11y-label-has-associated-control -->
<label>height:</label>
<input type="number" bind:value="{gameFieldRequest.height}" />

<button
  style="height: 20px; width:100px"
  on:click="{async () => await request()}">create</button>

<main>
  {#if hexGrid && hexGrid.length > 0}
    <HexGrid size="{10}" hexes={hexGrid}/>
  {/if}
</main>

<style>
  main {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #ecf0f1;
  }
</style>
