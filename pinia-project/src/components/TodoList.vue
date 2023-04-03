<script setup lang="ts">
import { TodoStatus } from '@/stores/todoStore';
import TodoGroup from './TodoGroup.vue';
</script>

<template>
    <div class="groups-wrapper">
        <TodoGroup :status="TodoStatus.Pending"/>
        <TodoGroup :status="TodoStatus.Completed"/>
    </div>
</template>

<style scoped>
    .groups-wrapper {
        display: flex;
        justify-content: space-around;
        gap: 20px;
    }
</style>