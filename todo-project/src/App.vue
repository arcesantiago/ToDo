<script setup lang="ts">
import ToDoList from './components/ToDoList.vue';
</script>

<template>
  <div class="app-wrapper">
    <div class="wrapper">
      <ToDoList/>
    </div>
  </div>
</template>

<style scoped>

.app-wrapper {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.logo {
  display: block;
}
@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }
  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
