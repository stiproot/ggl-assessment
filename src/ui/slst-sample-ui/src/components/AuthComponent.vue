<template>
  <div>AuthComponent</div>
</template>
<script>
import { onMounted } from "vue";

export default {
  name: "AuthComponent",
  setup() {
    function oauthSignIn() {

      var form = document.createElement("form");
      form.setAttribute("method", "GET");
      form.setAttribute("action", process.env.VUE_APP_AUTH_URL);

      var params = {
        client_id: process.env.VUE_APP_CLIENT_ID,
        redirect_uri: process.env.VUE_APP_REDIRECT_URL,
        response_type: "code",
        access_type: "offline",
        scope: "openid email profile",
        state: "pass-through value",
      };

      for (var p in params) {
        var input = document.createElement("input");
        input.setAttribute("type", "hidden");
        input.setAttribute("name", p);
        input.setAttribute("value", params[p]);
        form.appendChild(input);
      }

      document.body.appendChild(form);
      form.submit();
    }

    onMounted(() => {
      oauthSignIn();
    });

    return {};
  },
};
</script>
<style></style>
