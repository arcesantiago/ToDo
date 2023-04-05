<template>
    <div class="group-wrapper">
<h3>{{groupLabel[props.status]}}</h3>
<ul>
    <li v-for="todo in todoList" :key="todo.id">{{ todo.title }}

        <v-btn
        class="ma-2 delete-icon"
        variant="text"
        icon="mdi-close"
        size="x-small"
        color="error"
        @click="deleteTask(todo)"
      ></v-btn>
        <v-btn
        class="ma-2 delete-icon"
        variant="text"
        v-bind:icon="todo.status === 'pending' ? 'mdi-arrow-right' : 'mdi-arrow-left'"
        size="x-small"
        v-bind:color="todo.status === 'pending' ? 'success' : 'warning'"
        @click="updateTask(todo)"
      ></v-btn>
        <div>
            <span class="todo-description">{{ todo.description }}</span>
          </div>
    </li>
</ul>
<CreateTask :status="props.status" />
    </div>
</template>


<style scoped>
.group-wrapper {
  flex: 1;
  padding: 20px;
  background-color: rgb(56, 80, 103);
  width: 300px;
}
.group-wrapper li {
  list-style-type: none;
  background-color: aliceblue;
  color: rgb(56, 80, 103);
  padding: 2px 5px;
  margin-bottom: 10px;
}
.todo-description {
  font-size: 12px;
}
.delete-icon {
  float: right;
}
</style>

<script setup lang="ts">
import { TodoStatus, useTodoStore, type TodoItem } from '@/stores/todoStore';
import { computed } from 'vue';
import CreateTask from "./CreateTask.vue";
    interface Props {
      status: TodoStatus
    }
    const props = defineProps<Props>();

    const groupLabel = {
        [TodoStatus.Pending]: "Pending",
        [TodoStatus.Completed]: "Completed",
    }
    const store = useTodoStore()
     store.getList(props.status)
    const todoList = computed(() => store[props.status])

    const updateTask = async (item: TodoItem) => {
      await store.updateTask(item)
      store.getList(TodoStatus.Pending)
      store.getList(TodoStatus.Completed)
    }

    const deleteTask = async (item: TodoItem) => {
      await store.deleteTask(item)
      store.getList(props.status)
    }

</script>