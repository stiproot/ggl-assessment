<template>
  <div>LoginComponent</div>
</template>
<script>
import { onMounted } from "vue";
import { login } from "../services/auth.service";

export default {
  name: "LoginComponent",
  setup() {
    onMounted(() => {
      login();
    });

    return {};
  },
};
</script>
<style></style>
