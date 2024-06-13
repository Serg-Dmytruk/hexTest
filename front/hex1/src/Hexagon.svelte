<script lang="ts">
  import { Point2D } from "./models/Point2D";

  export let size: number;
  export let x: number;
  export let y: number;
  export let position: Point2D;
  
  let points: string = "";

  function pointy_hex_corner(center: Point2D, size: number, i: number): Point2D {
    const angle_deg: number = 60 * i - 30;
    const angle_rad: number = (Math.PI / 180) * angle_deg;
    return new Point2D({
      x: center.x + size * Math.cos(angle_rad),
      y: center.y + size * Math.sin(angle_rad),
    });
  }

  function calculateHexagonPoints(center: Point2D, size: number): string {
    let pts:string[] = [];
    for (let i = 0; i < 6; i++) {
      const corner: Point2D = pointy_hex_corner(center, size, i);
      pts.push(`${corner.x},${corner.y}`);
    }

    return pts.join(" ");
  }

  $: points = calculateHexagonPoints(new Point2D({ x, y }), size);
</script>

<svg>
  <polygon {points} fill="red" stroke="black"></polygon>
  <text x="{x}" y="{y}" text-anchor="middle" dominant-baseline="middle" fill="black" font-size="{size / 2}">
    x:{position.x},y:{position.y}
  </text>
</svg>

<style>
  svg {
    overflow: visible;
  }
</style>
